param(
  [string]$RepoRoot = ".",

  # legacy args (ignored if passed by old workflow)
  [string]$OutMd   = $null,
  [string]$OutJson = $null,

  # outputs
  [string]$OutDir   = ".\docs\pack",
  [string]$IndexOut = ".\docs\pack\index.json",
  [string]$TinyRoot = ".\docs\xbc-knowledge-pack.json",

  # options
  [switch]$IncludeTests   = $true,
  [switch]$IncludeSecrets = $false,
  [int]$MaxFileKB   = 512,     # truncate huge individual files
  [int]$MaxPartKB   = 1200     # ~1.2 MB per part target (keeps Action responses small)
)

function Get-FileHashHex($p){ (Get-FileHash -Algorithm SHA256 -Path $p).Hash.ToLower() }
function Slug($s){ ($s -replace '[^a-zA-Z0-9]+','-').ToLower() }

$includeExt = @(
  ".cs",".csproj",".sln",".props",".targets",".editorconfig",
  ".json",".yml",".yaml",".md",".sql",".ts",".tsx",".jsx",
  ".css",".scss",".razor",".cshtml",".http",".xml",".config",
  ".ps1",".sh",".bat",".dockerfile",".gitattributes",".gitignore"
)

# exclude noisy/sensitive folders
$excludeDir = '(?i)(/|\\)(\.git|bin|obj|node_modules|\.vs|logs|docs/pack)(/|\\)'
if (-not $IncludeTests) { $excludeDir = '(?i)(/|\\)(\.git|bin|obj|node_modules|\.vs|logs|docs/pack|tests|\.tests)(/|\\)' }

# exclude sensitive files
$excludeFile = '(?i)\.key$|\.pem$|\.pfx$|\.cer$|\.env|secrets'
if (-not $IncludeSecrets) { $excludeFile += '|appsettings\.Production\.json' }

function Lang($e){
  switch ($e.ToLower()) {
    ".cs"{"csharp"}; ".ts"{"typescript"}; ".tsx"{"tsx"}; ".jsx"{"jsx"}
    ".json"{"json"}; ".sql"{"sql"}; ".md"{"markdown"}; ".css"{"css"}; ".scss"{"scss"}
    ".razor"{"razor"}; ".cshtml"{"cshtml"}; ".xml"{"xml"}; ".config"{"xml"}
    ".ps1"{"powershell"}; ".sh"{"bash"}; ".bat"{"bat"}; ".yml"{"yaml"}; ".yaml"{"yaml"}
    default{"text"}
  }
}

# prep output
New-Item -ItemType Directory -Force -Path $OutDir | Out-Null
New-Item -ItemType File -Force -Path (Join-Path $OutDir ".nojekyll") | Out-Null

$generatedAt = Get-Date -Format 'yyyy-MM-dd HH:mm:ss K'
$index = [ordered]@{ version="2.2-chunked"; generatedAt=$generatedAt; modules=@() }

# top-level modules (no giant 'root')
$top = Get-ChildItem -Path $RepoRoot -Directory |
  Where-Object { $_.Name -notin @(".git",".github","docs","tools",".vs","obj","bin") }

$modules = @()
$modules += $top | ForEach-Object { [ordered]@{ name = $_.Name; root = $_.FullName } }

$MaxBytes   = $MaxFileKB * 1024
$TargetPart = $MaxPartKB * 1024

foreach ($m in $modules) {
  $name = $m.name; $slug = Slug $name; $root = $m.root

  $files = Get-ChildItem -Path $root -Recurse -File -ErrorAction SilentlyContinue |
    Where-Object { $includeExt -contains $_.Extension -or $_.Name -ieq "Dockerfile" } |
    Where-Object { $_.FullName -notmatch $excludeDir } |
    Where-Object { $_.FullName -notmatch $excludeFile } |
    Sort-Object FullName -Unique

  # read/prepare files
  $prepared = @()
  $totalBytes = 0
  foreach ($f in $files) {
    $rel = $f.FullName.Replace((Resolve-Path $RepoRoot),"").TrimStart("\","/")

    $text = $null
    try { $text = Get-Content -LiteralPath $f.FullName -Raw -ErrorAction Stop } catch {
      Write-Warning "Skip unreadable: $($f.FullName) — $_"; continue
    }
    if ($null -eq $text) { $text = "" }

    $size = [Text.Encoding]::UTF8.GetByteCount([string]$text)
    if ($size -gt $MaxBytes) {
      $text = $text.Substring(0, [Math]::Min($text.Length, $MaxBytes)) + "`n/* TRUNCATED for size */"
      $size = [Text.Encoding]::UTF8.GetByteCount($text)
    }

    $prepared += [ordered]@{
      path=$rel; sha256=(Get-FileHashHex $f.FullName); language=(Lang $f.Extension); size=$size; content=$text
    }
    $totalBytes += $size
  }

  # small module => single file
  if ($totalBytes -le $TargetPart) {
    $mod = [ordered]@{ name=$name; generatedAt=$generatedAt; files=$prepared }
    $outFile = Join-Path $OutDir "$slug.json"
    ($mod | ConvertTo-Json -Depth 14) | Out-File -Encoding utf8 $outFile

    $index.modules += [ordered]@{
      name=$name; slug=$slug; mode="single"; fileCount=$prepared.Count; bytes=$totalBytes;
      href="/busiorbit-api/pack/$slug.json"
    }
    Write-Host "Module $name -> single ($($prepared.Count) files, $totalBytes bytes)"
    continue
  }

  # large module => split into parts
  $partsDir = Join-Path $OutDir "$slug/parts"
  New-Item -ItemType Directory -Force -Path $partsDir | Out-Null
  New-Item -ItemType File -Force -Path (Join-Path $partsDir ".nojekyll") | Out-Null

  $partNum = 1
  $buf     = New-Object System.Collections.Generic.List[object]
  $bufBytes = 0
  $partsMeta = @()

  foreach ($pf in $prepared) {
    $thisSize = [int]$pf.size
    if ($bufBytes -gt 0 -and ($bufBytes + $thisSize) -gt $TargetPart) {
      $out = [ordered]@{ name=$name; part=$partNum; of=0; generatedAt=$generatedAt; files=$buf }
      $outPath = Join-Path $partsDir "$partNum.json"
      ($out | ConvertTo-Json -Depth 14) | Out-File -Encoding utf8 $outPath

      $partsMeta += [ordered]@{
        n=$partNum; href="/busiorbit-api/pack/$slug/parts/$partNum.json"; bytes=$bufBytes; fileCount=$buf.Count
      }
      $partNum += 1
      $buf     = New-Object System.Collections.Generic.List[object]
      $bufBytes = 0
    }
    $buf.Add($pf)
    $bufBytes += $thisSize
  }
  if ($buf.Count -gt 0) {
    $out = [ordered]@{ name=$name; part=$partNum; of=0; generatedAt=$generatedAt; files=$buf }
    $outPath = Join-Path $partsDir "$partNum.json"
    ($out | ConvertTo-Json -Depth 14) | Out-File -Encoding utf8 $outPath
    $partsMeta += [ordered]@{
      n=$partNum; href="/busiorbit-api/pack/$slug/parts/$partNum.json"; bytes=$bufBytes; fileCount=$buf.Count
    }
  }

  # annotate total part count
  $totalParts = $partsMeta.Count
  for ($i=1; $i -le $totalParts; $i++) {
    $p = Get-Content (Join-Path $partsDir "$i.json") -Raw | ConvertFrom-Json
    $p.of = $totalParts
    ($p | ConvertTo-Json -Depth 14) | Out-File -Encoding utf8 (Join-Path $partsDir "$i.json")
  }

  $index.modules += [ordered]@{
    name=$name; slug=$slug; mode="parts"; totalBytes=$totalBytes; partCount=$totalParts; parts=$partsMeta
  }
  Write-Host "Module $name -> parts=$totalParts (total $totalBytes bytes)"
}

# write index + tiny pointer
($index | ConvertTo-Json -Depth 8) | Out-File -Encoding utf8 $IndexOut
($index | Select-Object version, generatedAt | ConvertTo-Json) | Out-File -Encoding utf8 $TinyRoot

Write-Host "DONE. modules=$($index.modules.Count)"

param(
  [string]$RepoRoot = ".",

  # ---- legacy args (ignored if passed by old workflow) ----
  [string]$OutMd   = $null,
  [string]$OutJson = $null,

  # ---- current outputs ----
  [string]$OutDir   = ".\docs\pack",               # per-module JSONs
  [string]$IndexOut = ".\docs\pack\index.json",    # small index
  [string]$TinyRoot = ".\docs\xbc-knowledge-pack.json", # pointer for backward compat

  # ---- options ----
  [switch]$IncludeTests   = $true,   # set to $false to drop test projects
  [switch]$IncludeSecrets = $false,  # set to $true ONLY if you really want prod secrets included
  [int]$MaxFileKB = 512             # truncate files larger than this (in KB)
)

function Get-FileHashHex($p){ (Get-FileHash -Algorithm SHA256 -Path $p).Hash.ToLower() }
function Slug($s){ ($s -replace '[^a-zA-Z0-9]+','-').ToLower() }

# Include almost everything a dev/GPT needs to read
$includeExt = @(
  ".cs",".csproj",".sln",".props",".targets",".editorconfig",
  ".json",".yml",".yaml",".md",".sql",".ts",".tsx",".jsx",
  ".css",".scss",".razor",".cshtml",".http",".xml",".config",
  ".ps1",".sh",".bat",".dockerfile",".gitattributes",".gitignore"
)

# Directory excludes
$excludeDir = '(?i)(/|\\)(\.git|bin|obj|node_modules|\.vs|logs|docs/pack)(/|\\)'
if (-not $IncludeTests) { $excludeDir = '(?i)(/|\\)(\.git|bin|obj|node_modules|\.vs|logs|docs/pack|tests|\.tests)(/|\\)' }

# File excludes (secrets)
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

# ---- Output prep ----
New-Item -ItemType Directory -Force -Path $OutDir | Out-Null
# keep Pages from parsing anything here
New-Item -ItemType File -Force -Path (Join-Path $OutDir ".nojekyll") | Out-Null

$generatedAt = Get-Date -Format 'yyyy-MM-dd HH:mm:ss K'

# ---- Build module list: one per top-level folder + a "root" module ----
#$top = Get-ChildItem -Path $RepoRoot -Directory |
 # Where-Object { $_.Name -notin @(".git",".github","docs","tools",".vs","obj","bin") }

#$modules = @([ordered]@{ name = "root"; root = (Resolve-Path $RepoRoot).Path })
#$modules += $top | ForEach-Object { [ordered]@{ name = $_.Name; root = $_.FullName } }
##------------------------- Remove root from the grouping ------
# ---- Build module list: one per top-level folder (no 'root' to keep payloads small) ----
$top = Get-ChildItem -Path $RepoRoot -Directory |
  Where-Object { $_.Name -notin @(".git",".github","docs","tools",".vs","obj","bin") }

$modules = @()
$modules += $top | ForEach-Object { [ordered]@{ name = $_.Name; root = $_.FullName } }

# ---- Gather & write per-module JSON ----
$totalFiles = 0
$index = [ordered]@{ version="2.1-full"; generatedAt=$generatedAt; modules=@() }

foreach ($m in $modules) {
  $name = $m.name; $slug = Slug $name; $root = $m.root

  $files = Get-ChildItem -Path $root -Recurse -File -ErrorAction SilentlyContinue |
    Where-Object { $includeExt -contains $_.Extension -or $_.Name -ieq "Dockerfile" } |
    Where-Object { $_.FullName -notmatch $excludeDir } |
    Where-Object { $_.FullName -notmatch $excludeFile } |
    Sort-Object FullName -Unique

  $mod = [ordered]@{ name=$name; generatedAt=$generatedAt; files=@() }
  $bytes = 0
  $maxBytes = $MaxFileKB * 1024

  foreach ($f in $files) {
    $rel = $f.FullName.Replace((Resolve-Path $RepoRoot),"").TrimStart("\","/")

    # Safe read; skip if unreadable
    $text = $null
    try {
      $text = Get-Content -LiteralPath $f.FullName -Raw -ErrorAction Stop
    } catch {
      Write-Warning "Skipping unreadable file: $($f.FullName) — $_"
      continue
    }
    if ($null -eq $text) { $text = "" }

    $sizeBytes = [Text.Encoding]::UTF8.GetByteCount([string]$text)

    if ($sizeBytes -gt $maxBytes) {
      $text = $text.Substring(0, [Math]::Min($text.Length, $maxBytes)) + "`n/* TRUNCATED for size */"
      $sizeBytes = [Text.Encoding]::UTF8.GetByteCount($text)
    }

    $mod.files += [ordered]@{
      path=$rel; sha256=(Get-FileHashHex $f.FullName); language=(Lang $f.Extension);
      size=$sizeBytes; content=$text
    }
    $bytes += $sizeBytes
  }

  $outFile = Join-Path $OutDir "$slug.json"
  ($mod | ConvertTo-Json -Depth 14) | Out-File -Encoding utf8 $outFile

  $index.modules += [ordered]@{
    name=$name; slug=$slug; fileCount=$mod.files.Count; bytes=$bytes; href="/busiorbit-api/pack/$slug.json"
  }
  $totalFiles += $mod.files.Count
  Write-Host "Module $name -> $($mod.files.Count) files, $bytes bytes"
}

# ---- Write index + tiny pointer (for backward compatibility) ----
($index | ConvertTo-Json -Depth 6) | Out-File -Encoding utf8 $IndexOut
($index | Select-Object version, generatedAt | ConvertTo-Json) | Out-File -Encoding utf8 $TinyRoot

Write-Host "DONE: modules=$($index.modules.Count), totalFiles=$totalFiles"

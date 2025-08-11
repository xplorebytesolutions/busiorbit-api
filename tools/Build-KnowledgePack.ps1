param(
  [string]$RepoRoot = ".",
  [string]$OutMd   = ".\docs\xbc-knowledge-pack.md",
  [string]$OutJson = ".\docs\xbc-knowledge-pack.json"
)

function Get-FileHashHex($p){ (Get-FileHash -Algorithm SHA256 -Path $p).Hash.ToLower() }

# What we include / exclude
$includeExt = @(".cs",".ts",".tsx",".jsx",".json",".sql",".md",".css",".scss")
$excludeFile = '(?i)\.env|secrets|appsettings\.Production\.json'
$excludeDir  = '(?i)(/|\\)(\.git|bin|obj|node_modules|\.vs|logs|docs|tests)(/|\\)'

function Lang($e){
  switch ($e.ToLower()) {
    ".cs"{"csharp"}; ".ts"{"typescript"}; ".tsx"{"tsx"}; ".jsx"{"jsx"}
    ".json"{"json"}; ".sql"{"sql"}; ".md"{"markdown"}; ".css"{"css"}; ".scss"{"scss"}
    default{"text"}
  }
}

# Backend root = xbytechat-api (first choice), or xbytechat.api, else repo root
$backendRoot =
  @("xbytechat-api","xbytechat.api",".") |
  ForEach-Object {
    $p = Join-Path $RepoRoot $_
    if (Test-Path $p) { (Resolve-Path $p).Path }
  } | Select-Object -First 1

Write-Host "BackendRoot: $backendRoot"

# Collect files
$files = Get-ChildItem -Path $backendRoot -Recurse -File -ErrorAction SilentlyContinue |
  Where-Object { $_.FullName -notmatch $excludeDir } |
  Where-Object { $includeExt -contains $_.Extension } |
  Where-Object { $_.FullName -notmatch $excludeFile } |
  Sort-Object FullName -Unique

# Also include any Migrations (even if path contains excluded word)
$migrationDirs = Get-ChildItem -Path $backendRoot -Directory -Recurse -ErrorAction SilentlyContinue |
  Where-Object { $_.Name -ieq 'Migrations' }
foreach ($dir in $migrationDirs) {
  $files += Get-ChildItem -Path $dir.FullName -Recurse -File -ErrorAction SilentlyContinue |
    Where-Object { $includeExt -contains $_.Extension }
}
$files = $files | Sort-Object FullName -Unique

# Write outputs
New-Item -ItemType Directory -Force -Path (Split-Path $OutMd) | Out-Null
$generatedAt = Get-Date -Format 'yyyy-MM-dd HH:mm:ss K'
$md   = "# xByteChat Knowledge Pack`nGenerated: $generatedAt`n"
$pack = [ordered]@{ version="1.0"; generatedAt=$generatedAt; modules=@() }

# Single module: Backend
$jsonFiles = @()
foreach ($f in $files) {
  $rel = $f.FullName.Replace((Resolve-Path $RepoRoot),"").TrimStart("\","/")
  $hash = Get-FileHashHex $f.FullName
  $lang = Lang $f.Extension
  $content = Get-Content $f.FullName -Raw

  $md += "`n--- file: $rel  (sha256:$hash)`n```$lang`n$content`n````n"
  $jsonFiles += [ordered]@{ path=$rel; sha256=$hash; language=$lang; content=$content }
}
$pack.modules += [ordered]@{ name="Backend"; files=$jsonFiles }

$md | Out-File -Encoding utf8 $OutMd
($pack | ConvertTo-Json -Depth 12) | Out-File -Encoding utf8 $OutJson
Write-Host "Generated: $OutMd, $OutJson (files: $($jsonFiles.Count))"

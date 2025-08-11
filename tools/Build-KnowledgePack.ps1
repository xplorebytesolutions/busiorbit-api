param(
  [string]$RepoRoot = ".",
  [string]$OutMd = ".\docs\xbc-knowledge-pack.md",
  [string]$OutJson = ".\docs\xbc-knowledge-pack.json"
)

function Get-FileHashHex($path) { (Get-FileHash -Algorithm SHA256 -Path $path).Hash.ToLower() }

# ---- CONFIG ----
$includeExt = @(".cs",".ts",".tsx",".jsx",".json",".sql",".md")
$excludeRegex = '(\\\.git\\\|\\\bin\\\|\\\obj\\\|node_modules|\\.env|secrets|appsettings\\.Production\\.json)$'

# Discover modules under Features/*
$featuresRoot = Join-Path $RepoRoot "Features"
$modules =
  if (Test-Path $featuresRoot) {
    Get-ChildItem -Path $featuresRoot -Directory -Recurse |
      Where-Object { $_.Parent.FullName -eq (Resolve-Path $featuresRoot) } |
      Select-Object -ExpandProperty Name
  } else { @() }

# Fallback if no Features directory (optional)
if ($modules.Count -eq 0) {
  $modules = @("Businesses","Messages","Catalog","Campaigns","Contacts","Tags","Reminders","CatalogClickLogs","CatalogDashboard")
}

# Helpers
function File-Lang($ext) {
  switch ($ext.ToLower()) {
    ".cs"  { "csharp" }
    ".ts"  { "typescript" }
    ".tsx" { "tsx" }
    ".jsx" { "jsx" }
    ".json"{ "json" }
    ".sql" { "sql" }
    ".md"  { "markdown" }
    default { "text" }
  }
}

# Ensure docs dir
New-Item -ItemType Directory -Force -Path (Split-Path $OutMd) | Out-Null

$generatedAt = Get-Date -Format 'yyyy-MM-dd HH:mm:ss K'
$md = "# xByteChat Knowledge Pack`nGenerated: $generatedAt`n"
$pack = [ordered]@{
  version = "1.0"
  generatedAt = $generatedAt
  modules = @()
}

foreach ($m in $modules) {
  $md += "`n=== MODULE: $m (updated: $(Get-Date -Format 'yyyy-MM-dd'))`n"

  $modulePath = Join-Path $featuresRoot $m
  $files = @()

  if (Test-Path $modulePath) {
    $files += Get-ChildItem -Path $modulePath -Recurse -File -ErrorAction SilentlyContinue
  }

  # Pull migrations mentioning this module by name (optional heuristic)
  $migrationsPath = Join-Path $RepoRoot "Migrations"
  if (Test-Path $migrationsPath) {
    $files += Get-ChildItem -Path $migrationsPath -Recurse -File -ErrorAction SilentlyContinue |
      Where-Object { $_.Name -match $m }
  }

  $files = $files |
    Where-Object { $includeExt -contains $_.Extension } |
    Where-Object { $_.FullName -notmatch $excludeRegex } |
    Sort-Object FullName -Unique

  $jsonFiles = @()

  foreach ($f in $files) {
    $rel = $f.FullName.Replace((Resolve-Path $RepoRoot), "").TrimStart("\","/")
    $hash = Get-FileHashHex $f.FullName
    $lang = File-Lang $f.Extension
    $content = Get-Content $f.FullName -Raw

    # Append to MD
    $md += "`n--- file: $rel  (sha256:$hash)`n```$lang`n$content`n````n"

    # Add to JSON
    $jsonFiles += [ordered]@{
      path = $rel
      sha256 = $hash
      language = $lang
      content = $content
    }
  }

  $pack.modules += [ordered]@{
    name  = $m
    files = $jsonFiles
  }
}

# Write outputs
$md | Out-File -Encoding utf8 $OutMd
($pack | ConvertTo-Json -Depth 10) | Out-File -Encoding utf8 $OutJson
Write-Host "Generated: $OutMd, $OutJson"

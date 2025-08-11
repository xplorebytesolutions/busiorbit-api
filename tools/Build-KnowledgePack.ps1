param(
  [string]$RepoRoot = ".",
  [string]$OutMd = ".\docs\xbc-knowledge-pack.md",
  [string]$OutJson = ".\docs\xbc-knowledge-pack.json"
)

function Get-FileHashHex($path) { (Get-FileHash -Algorithm SHA256 -Path $path).Hash.ToLower() }

# ---- CONFIG ----
$includeExt = @(".cs",".ts",".tsx",".jsx",".json",".sql",".md",".css",".scss")
$excludeFileRegex = '(?i)\.env|secrets|appsettings\.Production\.json'
$excludeDirRegex  = '(?i)(/|\\)(\.git|bin|obj|node_modules|docs|tests|\.vs)(/|\\)'

function File-Lang($ext) {
  switch ($ext.ToLower()) {
    ".cs"  { "csharp" }
    ".ts"  { "typescript" }
    ".tsx" { "tsx" }
    ".jsx" { "jsx" }
    ".json"{ "json" }
    ".sql" { "sql" }
    ".md"  { "markdown" }
    ".css" { "css" }
    ".scss"{ "scss" }
    default { "text" }
  }
}

# ---- DISCOVERY: find Features & Migrations anywhere ----
$featuresHit = Get-ChildItem -Path $RepoRoot -Directory -Recurse -ErrorAction SilentlyContinue |
  Where-Object { $_.Name -ieq 'Features' } |
  Sort-Object { $_.FullName.Split([System.IO.Path]::DirectorySeparatorChar).Count } |
  Select-Object -First 1
$featuresRoot = if ($featuresHit) { $featuresHit.FullName } else { $null }

$migrationDirs = Get-ChildItem -Path $RepoRoot -Directory -Recurse -ErrorAction SilentlyContinue |
  Where-Object { $_.Name -ieq 'Migrations' }

if ($featuresRoot) {
  $modules = Get-ChildItem -Path $featuresRoot -Directory -ErrorAction SilentlyContinue |
             Select-Object -ExpandProperty Name
} else {
  $modules = @('Backend')   # fallback: scan whole repo
}

# Log what we detected (shows up in Actions)
Write-Host "FeaturesRoot: $featuresRoot"
Write-Host "Modules: $($modules -join ', ')"
Write-Host "MigrationDirs: $(@($migrationDirs | ForEach-Object {$_.FullName}) -join ' | ')"

# ---- OUTPUT PREP ----
New-Item -ItemType Directory -Force -Path (Split-Path $OutMd) | Out-Null
$generatedAt = Get-Date -Format 'yyyy-MM-dd HH:mm:ss K'
$md = "# xByteChat Knowledge Pack`nGenerated: $generatedAt`n"
$pack = [ordered]@{ version = "1.0"; generatedAt = $generatedAt; modules = @() }

foreach ($m in $modules) {
  $md += "`n=== MODULE: $m (updated: $(Get-Date -Format 'yyyy-MM-dd'))`n"
  $files = @()

  if ($featuresRoot -and $m -ne 'Backend') {
    $modulePath = Join-Path $featuresRoot $m
    if (Test-Path $modulePath) {
      $files += Get-ChildItem -Path $modulePath -Recurse -File -ErrorAction SilentlyContinue
    }
  } else {
    # catch-all: scan whole repo (minus excluded dirs)
    $files += Get-ChildItem -Path $RepoRoot -Recurse -File -ErrorAction SilentlyContinue |
              Where-Object { $_.FullName -notmatch $excludeDirRegex }
  }

  # add ALL migrations
  foreach ($dir in $migrationDirs) {
    $files += Get-ChildItem -Path $dir.FullName -Recurse -File -ErrorAction SilentlyContinue
  }

  $files = $files |
    Where-Object { $includeExt -contains $_.Extension } |
    Where-Object { $_.FullName -notmatch $excludeFileRegex } |
    Where-Object { $_.FullName -notmatch $excludeDirRegex } |
    Sort-Object FullName -Unique

  $jsonFiles = @()
  foreach ($f in $files) {
    $rel = $f.FullName.Replace((Resolve-Path $RepoRoot), "").TrimStart("\","/")
    $hash = Get-FileHashHex $f.FullName
    $lang = File-Lang $f.Extension
    $content = Get-Content $f.FullName -Raw
    $md += "`n--- file: $rel  (sha256:$hash)`n```$lang`n$content`n````n"
    $jsonFiles += [ordered]@{ path = $rel; sha256 = $hash; language = $lang; content = $content }
  }

  $pack.modules += [ordered]@{ name = $m; files = $jsonFiles }
}

$md | Out-File -Encoding utf8 $OutMd
($pack | ConvertTo-Json -Depth 12) | Out-File -Encoding utf8 $OutJson
Write-Host "Generated: $OutMd, $OutJson (module-count: $($modules.Count))"

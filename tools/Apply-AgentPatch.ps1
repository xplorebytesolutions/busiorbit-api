param(
  [string]$RepoRoot = ".",
  [switch]$AutoCommit = $false,
  [string]$CommitMessage = "feat(agent): apply patch"
)

function Fail($msg){ Write-Host "❌ $msg"; exit 1 }
function Ok($msg){ Write-Host "✅ $msg" }

# Ensure git exists
$git = (Get-Command git -ErrorAction SilentlyContinue)
if (-not $git) { Fail "git not found in PATH" }

# Resolve repo root
Push-Location $RepoRoot
$top = (& git rev-parse --show-toplevel 2>$null)
if (-not $top) { Pop-Location; Fail "Not inside a git repo: $RepoRoot" }
Set-Location $top

# Read patch from clipboard
try {
  $patchText = Get-Clipboard -Raw
} catch {
  Fail "Could not read clipboard. Copy the agent's ```patch content first."
}
if ([string]::IsNullOrWhiteSpace($patchText) -or ($patchText -notmatch '^(diff --git|Index: )')) {
  Fail "Clipboard doesn't look like a unified diff. Make sure you copied the text inside ```patch fences."
}

# Save to temp file
$patchFile = Join-Path $env:TEMP "agent.patch"
$patchText | Out-File -Encoding utf8 $patchFile

# Apply with 3-way merge and stage changes
Write-Host "🔧 Applying patch..."
$apply = & git apply --3way --whitespace=fix --index "$patchFile" 2>&1
if ($LASTEXITCODE -ne 0) {
  Write-Host $apply
  Fail "git apply failed. Resolve conflicts or ask the agent to rebase the patch."
}

# Show staged files
$staged = & git diff --cached --name-only
if (-not $staged) { Fail "No files staged. Nothing changed?" }

Ok "Patch applied and staged:"
$staged | ForEach-Object { Write-Host "  • $_" }

# Try to open changed files in Visual Studio (if available in PATH)
$devenv = (Get-Command devenv.exe -ErrorAction SilentlyContinue)
if ($devenv) {
  Write-Host "🧭 Opening files in Visual Studio..."
  # Limit to a reasonable number of files on command line
  $open = $staged | Select-Object -First 12
  & $devenv.Path /Edit @($open)
}

if ($AutoCommit) {
  & git commit -m $CommitMessage
  if ($LASTEXITCODE -eq 0) { Ok "Committed." } else { Write-Host "⚠️ Commit failed; you can commit manually." }
}

Pop-Location
Ok "Done."

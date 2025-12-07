<#
.SYNOPSIS
    Publishes the Toggl.Api NuGet package to nuget.org

.DESCRIPTION
    This script performs the following steps:
    1. Checks for git porcelain (clean working directory)
    2. Determines the Nerdbank git version
    3. Checks that nuget-key.txt exists, has content, and is gitignored
    4. Runs unit tests (unless -SkipTests is specified)
    5. Publishes to nuget.org

.PARAMETER SkipTests
    If specified, skips running unit tests

.EXAMPLE
    .\Publish.ps1
    .\Publish.ps1 -SkipTests
#>

param(
    [switch]$SkipTests
)

$ErrorActionPreference = 'Stop'

# Step 1: Check for git porcelain (clean working directory)
Write-Host "Checking for clean git working directory..." -ForegroundColor Cyan
$gitStatus = git status --porcelain
if ($gitStatus) {
    Write-Error "Git working directory is not clean. Please commit or stash your changes before publishing."
    exit 1
}
Write-Host "Git working directory is clean." -ForegroundColor Green

# Step 2: Determine the Nerdbank git version
Write-Host "Determining Nerdbank git version..." -ForegroundColor Cyan
$versionOutput = nbgv get-version -f json 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to get Nerdbank git version. Ensure nbgv tool is installed: dotnet tool install -g nbgv"
    exit 1
}
$versionInfo = $versionOutput | ConvertFrom-Json
$version = $versionInfo.NuGetPackageVersion
if (-not $version) {
    Write-Error "Failed to determine NuGet package version from Nerdbank.GitVersioning."
    exit 1
}
Write-Host "Version: $version" -ForegroundColor Green

# Step 3: Check that nuget-key.txt exists, has content, and is gitignored
Write-Host "Checking nuget-key.txt..." -ForegroundColor Cyan
$nugetKeyPath = Join-Path $PSScriptRoot "nuget-key.txt"

if (-not (Test-Path $nugetKeyPath)) {
    Write-Error "nuget-key.txt does not exist. Create it with your NuGet API key."
    exit 1
}

$nugetKey = (Get-Content $nugetKeyPath -Raw).Trim()
if ([string]::IsNullOrWhiteSpace($nugetKey)) {
    Write-Error "nuget-key.txt is empty. Add your NuGet API key."
    exit 1
}

# Check if nuget-key.txt is gitignored
$gitCheckIgnore = git check-ignore $nugetKeyPath 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Error "nuget-key.txt is not gitignored. Add 'nuget-key.txt' to your .gitignore file."
    exit 1
}
Write-Host "nuget-key.txt is valid and gitignored." -ForegroundColor Green

# Step 4: Run unit tests (unless -SkipTests is specified)
if (-not $SkipTests) {
    Write-Host "Running unit tests..." -ForegroundColor Cyan
    dotnet test --configuration Release --no-build
    if ($LASTEXITCODE -ne 0) {
        # Retry with build
        dotnet test --configuration Release
        if ($LASTEXITCODE -ne 0) {
            Write-Error "Unit tests failed."
            exit 1
        }
    }
    Write-Host "Unit tests passed." -ForegroundColor Green
}
else {
    Write-Host "Skipping unit tests." -ForegroundColor Yellow
}

# Step 5: Build and publish to nuget.org
Write-Host "Building package..." -ForegroundColor Cyan
dotnet build --configuration Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed."
    exit 1
}

dotnet pack --configuration Release --no-build
if ($LASTEXITCODE -ne 0) {
    Write-Error "Pack failed."
    exit 1
}

$packagePath = Get-ChildItem -Path "$PSScriptRoot\Toggl.Api\bin\Release\Toggl.Api.$version.nupkg" -ErrorAction SilentlyContinue
if (-not $packagePath) {
    # Try finding any matching package
    $packagePath = Get-ChildItem -Path "$PSScriptRoot\Toggl.Api\bin\Release\*.nupkg" | Select-Object -First 1
}

if (-not $packagePath) {
    Write-Error "Could not find NuGet package to publish."
    exit 1
}

Write-Host "Publishing $($packagePath.Name) to nuget.org..." -ForegroundColor Cyan
dotnet nuget push $packagePath.FullName --api-key $nugetKey --source https://api.nuget.org/v3/index.json --skip-duplicate
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to publish to nuget.org."
    exit 1
}

Write-Host "Successfully published Toggl.Api $version to nuget.org!" -ForegroundColor Green
exit 0

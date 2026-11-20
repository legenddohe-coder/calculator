<#
.SYNOPSIS
    Builds a standalone, self-contained single-file release of the Calculator.
.DESCRIPTION
    Compiles the project into a native Windows x64 single-file executable
    that does not require the .NET SDK or Runtime to be installed on the user's PC.
#>

param(
    [string]$OutputDir = "./release",
    [string]$Configuration = "Release",
    [string]$Runtime = "win-x64"
)

$ErrorActionPreference = "Stop"

Write-Host "=============================================" -ForegroundColor Cyan
Write-Host "  Building Calculator Standalone Release     " -ForegroundColor Cyan
Write-Host "=============================================" -ForegroundColor Cyan

# Stop any running instances to avoid file-lock errors
Get-Process calculator -ErrorAction SilentlyContinue | Stop-Process -Force

# Clean output directory
if (Test-Path $OutputDir) {
    Remove-Item -Path $OutputDir -Recurse -Force
}

Write-Host "[1/2] Publishing self-contained single-file binary..." -ForegroundColor Yellow
dotnet publish calculator/calculator.csproj `
    -c $Configuration `
    -r $Runtime `
    --self-contained true `
    /p:PublishSingleFile=true `
    /p:IncludeNativeLibrariesForSelfExtract=true `
    /p:EnableCompressionInSingleFile=true `
    -o $OutputDir

if ($LASTEXITCODE -eq 0) {
    $exePath = Join-Path $OutputDir "calculator.exe"
    $fileSizeMB = (Get-Item $exePath).Length / 1MB

    Write-Host "[2/2] Build Succeeded!" -ForegroundColor Green
    Write-Host "Output: $exePath" -ForegroundColor Green
    Write-Host ("Executable Size: {0:N2} MB" -f $fileSizeMB) -ForegroundColor Green
    Write-Host "=============================================" -ForegroundColor Cyan
    Write-Host "You can now distribute '$exePath' to any Windows PC." -ForegroundColor Cyan
} else {
    Write-Host "Build Failed with exit code $LASTEXITCODE." -ForegroundColor Red
    exit $LASTEXITCODE
}

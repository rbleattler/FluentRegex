#requires -Version 6.0
using namespace System.Collections.Generic;

[CmdletBinding(DefaultParameterSetName = 'Default')]
param(
  [Parameter(ParameterSetName = 'Package')]
  [string]
  $Version = '0.0.1',
  [Parameter(ParameterSetName = 'Default')]
  [Parameter(ParameterSetName = 'Package')]
  [ValidateSet('Debug', 'Release')]
  [string]
  $Configuration = 'Release',
  [Parameter(ParameterSetName = 'Default')]
  [Parameter(ParameterSetName = 'Package')]
  [ValidateSet('Clean', 'Restore', 'Build', 'Test', 'Publish', 'Pack')]
  [List[string]]
  $Steps = @( 'Clean', 'Restore', 'Build', 'Test', 'Publish', 'Pack'),
  [Parameter(ParameterSetName = 'Default')]
  [Parameter(ParameterSetName = 'Package')]
  [string]
  $OutputDirectory = "$PSScriptRoot\..\scratch"
)
begin {
  Write-Debug "[Begin]:[LocalBuild.ps1]:[Enter]"
  function Invoke-LocalBuild {
    param(
      [string]
      $Version = '0.0.1',
      [switch]
      $Pack,
      [string]
      $Configuration,
      [List[string]]
      $Steps
    )
    Write-Verbose "[Invoke-LocalBuild]:: Steps: $($Steps -join ', ')"
    switch ($Steps) {
      'Clean' {
        Write-Host "Cleaning project..." -ForegroundColor Yellow &&
        Write-Verbose "[CLEAN]"
        dotnet clean
      }
      'Restore' {
        Write-Host "Restoring packages..." -ForegroundColor Yellow &&
        Write-Verbose "[RESTORE]"
        dotnet restore
      }
      'Build' {
        Write-Host "Building version $Version..." -ForegroundColor Yellow &&
        Write-Verbose "[BUILD]"
        dotnet build --configuration $Configuration
      }
      'Test' {
        Write-Host "Running tests..." -ForegroundColor Yellow &&
        Write-Verbose "[TEST]"
        dotnet test
      }
      'Publish' {
        Write-Host "Publishing..." -ForegroundColor Yellow &&
        Write-Verbose "[PUBLISH]"
        dotnet publish $PSScriptRoot\..\src\FluentRegex\FluentRegex.csproj --configuration $Configuration /p:version="$Version" /p:PackageVersion="$Version" /p:InformationalVersion="$Version-local"
      }
      'Pack' {
        Write-Host "Packaging..." -ForegroundColor Yellow &&
        Write-Verbose "[PACK]"
        dotnet pack $PSScriptRoot\..\src\FluentRegex\FluentRegex.csproj --output $OutputDirectory -p:NuspecFile=$PSScriptRoot\..\src\FluentRegex\FluentRegex.nuspec -p:version="$($Version)" /p:PackageVersion="$($Version)" /p:PackageReleaseNotes="Local build" /p:PackageTags="local" /p:NugetVersion="$($Version)-local"
      }
      default {
        Write-Warning "I'm not sure what you're trying to do here... But we're going to assume it's 'Everything' and start over..."
        Invoke-LocalBuild -Version $Version -Pack $Pack -Configuration $Configuration -Steps @( 'Clean', 'Restore', 'Build', 'Test', 'Publish' )
      }
    }
  }
  if ($Steps.Count -eq 0) {
    Write-Warning "No steps were provided. Defaulting to 'Everything'..."
    $PSBoundParameters["Steps"] = @( 'Clean', 'Restore', 'Build', 'Test', 'Publish', 'Pack' )
    # $Steps = @( 'Clean', 'Restore', 'Build', 'Test', 'Publish','Pack' )
  }
  Write-Debug "[Begin][LocalBuild.ps1][Exit]"
}
process {
  Write-Debug "[Process][LocalBuild.ps1][Enter]"

  Write-Verbose "Steps: $($Steps -join ', ')"
  Invoke-LocalBuild @PSBoundParameters

  Write-Debug "[Process][LocalBuild.ps1][Exit]"
}
end {
  Write-Debug "[End][LocalBuild.ps1][Enter]"
  Write-Debug "[End][LocalBuild.ps1][Exit]"
}
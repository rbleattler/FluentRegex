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
      $Version,
      [switch]
      $Pack,
      [string]
      $Configuration,
      [List[string]]
      $Steps
    )
    switch ($Steps) {
      'Clean' {
        Write-Host "Cleaning project..." -ForegroundColor Yellow &&
        dotnet clean
      }
      'Restore' {
        Write-Host "Restoring packages..." -ForegroundColor Yellow &&
        dotnet restore
      }
      'Build' {
        Write-Host "Building version $Version..." -ForegroundColor Yellow &&
        dotnet build
      }
      'Test' {
        Write-Host "Running tests..." -ForegroundColor Yellow &&
        dotnet test
      }
      'Publish' {
        Write-Host "Publishing..." -ForegroundColor Yellow &&
        dotnet publish $PSScriptRoot\..\src\FluentRegex\FluentRegex.csproj --configuration $Configuration /p:version="$Version" /p:PackageVersion="$Version" /p:InformationalVersion="$Version-local"
      }
      'Pack' {
        Write-Host "Packaging..." -ForegroundColor Yellow &&
        dotnet pack $PSScriptRoot\..\src\FluentRegex\FluentRegex.csproj --output $OutputDirectory -p:NuspecFile=$PSScriptRoot\..\src\FluentRegex\FluentRegex.nuspec -p:version="$($Version)" /p:PackageVersion="$($Version)" /p:PackageReleaseNotes="Local build" /p:PackageTags="local"
      }
      default {
        Write-Warning "I'm not sure what you're trying to do here... But we're going to assume it's 'Everything' and start over..."
        Invoke-LocalBuild -Version $Version -Pack $Pack -Configuration $Configuration -Steps @( 'Clean', 'Restore', 'Build', 'Test', 'Publish' )
      }
    }
  }

  Write-Debug "[Begin][LocalBuild.ps1][Exit]"
}
process {
  Write-Debug "[Process][LocalBuild.ps1][Enter]"

  Invoke-LocalBuild @PSBoundParameters

  Write-Debug "[Process][LocalBuild.ps1][Exit]"
}
end {
  Write-Debug "[End][LocalBuild.ps1][Enter]"
  Write-Debug "[End][LocalBuild.ps1][Exit]"
}
param(
  [Parameter(ParameterSetName = 'Package')]
  [string]
  $Version = '0.0.1',
  [Parameter(ParameterSetName = 'Package')]
  [switch]
  $Pack,
  [Parameter(ParameterSetName = 'Package')]
  [ValidateSet('Debug', 'Release')]
  [string]
  $Configuration = 'Release'
)
Write-Host "Cleaning project..." -ForegroundColor Yellow &&
dotnet clean &&
Write-Host "Restoring packages..." -ForegroundColor Yellow &&
dotnet restore &&
Write-Host "Building version $Version..." -ForegroundColor Yellow &&
dotnet build &&
Write-Host "Running tests..." -ForegroundColor Yellow &&
dotnet test &&
Write-Host "Publishing..." -ForegroundColor Yellow &&
dotnet publish $PSScriptRoot\..\src\RegExpBuilder\RegExpBuilder.csproj --configuration $Configuration /p:Version="$Version" /p:InformationalVersion="$Version-local" &&
if ($PSCmdlet.ParameterSetName -eq 'Package' -and $Pack){
  dotnet pack $PSScriptRoot\..\src\RegExpBuilder\RegExpBuilder.csproj --output $PSScriptRoot\..\scratch -p:NuspecFile=$PSScriptRoot\..\src\RegExpBuilder\RegExpBuilder.nuspec -p:version="$Version" /p:PackageVersion="$Version" /p:PackageReleaseNotes="Local build" /p:PackageTags="local"
}

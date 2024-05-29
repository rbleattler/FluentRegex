param(
  [string]
  $Version = '1.0.1'
)
dotnet clean &&
dotnet restore &&
dotnet build &&
dotnet test &&
dotnet publish $PSScriptRoot\..\src\FluentRegex\FluentRegex.csproj --configuration Release /p:Version="$Version" /p:InformationalVersion="$Version-local" &&
dotnet pack $PSScriptRoot\..\src\FluentRegex\FluentRegex.csproj --output $PSScriptRoot\..\scratch -p:NuspecFile=$PSScriptRoot\..\src\FluentRegex\FluentRegex.nuspec -p:version="$Version" /p:PackageVersion="$Version" /p:PackageReleaseNotes="Local build" /p:PackageTags="local"
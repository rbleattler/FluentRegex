param(
  [string]
  $Version = '1.0.1'
)
dotnet clean &&
dotnet restore &&
dotnet build &&
dotnet test &&
dotnet publish $PSScriptRoot\..\src\RegExpBuilder\RegExpBuilder.csproj --configuration Release /p:Version="$Version" /p:InformationalVersion="$Version-local" &&
dotnet pack $PSScriptRoot\..\src\RegExpBuilder\RegExpBuilder.csproj --output $PSScriptRoot\..\scratch -p:NuspecFile=$PSScriptRoot\..\src\RegExpBuilder\RegExpBuilder.nuspec -p:version="$Version" /p:PackageVersion="$Version" /p:PackageReleaseNotes="Local build" /p:PackageTags="local"
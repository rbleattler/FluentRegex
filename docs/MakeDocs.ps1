<#
  .SYNOPSIS
    This script generates the documentation for the library using XmlDoc2Markdown.

  .DESCRIPTION
    This script generates the documentation for the library using XmlDoc2Markdown.
#>
param(
  [Parameter()]
  [ValidateSet("Debug", "Release")]
  $Configuration = "Debug"
)
begin {
  Write-Debug "Enter [$($PSCmdlet.MyInvocation.MyCommand.Name)]..."
  $PSBoundParameters.Keys.ForEach{
    if ($PSBoundParameters.PSItem -is [string]) {
      Write-Debug "$_ : $($PSBoundParameters.Item($_))"
    } else {
      Write-Debug "$_ : $($PSBoundParameters.Item($_).GetType())"
    }
  }
  $IsDotnetInstalled = $env:DOTNET_ROOT -ne $null
  if (-not $IsDotnetInstalled) {
    Write-Error "The .NET SDK is not installed. Please install the .NET SDK and set the DOTNET_ROOT environment variable."
    exit 1
  }
  $IsXmlDoc2MarkdownInstalled = Get-Command -Name XmlDoc2md -ErrorAction SilentlyContinue
  if (-not $IsXmlDoc2MarkdownInstalled) {
    Write-Error "XmlDoc2Markdown is not installed. Please install XmlDoc2Markdown. Use the following command to install XmlDoc2Markdown: dotnet tool install -g XmlDoc2Markdown"
    exit 1
  }
  $IsGitInstalled = Get-Command -Name git -ErrorAction SilentlyContinue
  if (-not $IsGitInstalled) {
    Write-Error "Git is not installed. Please install Git."
    exit 1
  }
}
process {
  $ProjectName = 'RegExpBuilder'
  $ProjectDotNetVersion = '8.0'
  $ProjectDirectory = Resolve-Path "$PSScriptRoot\..\src\$ProjectName"
  $LibraryPath = '{0}\bin\{1}\net{2}\{3}.dll' -f $ProjectDirectory, $Configuration, $ProjectDotNetVersion, $ProjectName
  $outputPath = Resolve-Path $PSScriptRoot
  Write-Output "Generating documentation for $ProjectName..."
  Write-Output "Project Path: $LibraryPath"
  Write-Output "Output Path: $OutputPath"
  . xmldoc2md.exe $LibraryPath $OutputPath
  Write-Output "Finished Generating Documentation!"
}
end {
  Write-Debug "Exit [$($PSCmdlet.MyInvocation.MyCommand.Name)]..."
}
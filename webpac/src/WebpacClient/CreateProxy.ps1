#
# CreateProxy.ps1
#
$ProjectFolder = $PSScriptRoot
$SwaggerFile = Join-Path $ProjectFolder "swagger.json"
$GeneratedSourcesFolder = Join-Path $ProjectFolder "Generated"
$Autorest = Join-Path $env:HOMEPATH ".nuget\packages\autorest\0.16.0\tools\AutoRest.exe"
$Parameters = " -CodeGenerator CSharp -Modeler Swagger -Input $SwaggerFile -Namespace Webpac.Client -OutputDirectory $GeneratedSourcesFolder -ClientName WebPacClient"

Invoke-WebRequest -Uri http://localhost:5000/swagger/v1/swagger.json -OutFile $SwaggerFile
[System.Diagnostics.Process]::Start($Autorest,$Parameters)

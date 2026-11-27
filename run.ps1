$ErrorActionPreference = 'Stop'
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) { throw 'Install .NET 8 SDK first: https://dotnet.microsoft.com/download/dotnet/8.0' }
dotnet run --project (Join-Path $PSScriptRoot 'REDSHIFT.csproj')

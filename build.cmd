
# usage: ./fake.sh

set COREWIN=Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5/
set FSHARPCORE=Reference Assemblies/Microsoft/FSharp/.NETFramework/v4.0/4.3.1.0
 
set PATH=%COREWIN%;%FSHARPCORE%;%PATH%

echo %PATH%
cd %~dp0

".paket/paket.exe" restore
".paket/paket.exe" install
"packages/FAKE/tools/Fake.exe" build.fsx %*
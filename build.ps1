$buildDir = ".\build"
if (test-path $buildDir) { ri -r -fo $buildDir }
.\tools\psake\psake.ps1 default.ps1 Compile 2.0
.\tools\psake\psake.ps1 default.ps1 Compile 4.0
.\Tools\nuget\NuGet.exe pack .\SGMLReader.nuspec -BasePath $buildDir -OutputDirectory $buildDir

rm -rf IIS.SLSharp.NuGet/App_Readme
mkdir IIS.SLSharp.NuGet/App_Readme

rm -rf IIS.SLSharp.NuGet/lib
mkdir IIS.SLSharp.NuGet/lib

cp bin/Release/IIS.SLSharp.dll IIS.SLSharp.NuGet/lib
cp bin/Release/IIS.SLSharp.xml IIS.SLSharp.NuGet/lib

cp bin/Release/IIS.SLSharp.Bindings.*.dll IIS.SLSharp.NuGet/lib
cp bin/Release/IIS.SLSharp.Bindings.*.xml IIS.SLSharp.NuGet/lib

cp Dependencies/*.dll IIS.SLSharp.NuGet/lib
cp Dependencies/*.xml IIS.SLSharp.NuGet/lib

cp README.md IIS.SLSharp.NuGet/App_Readme/SLSharp.readme.txt

Dependencies/NuGet.exe pack "IIS.SLSharp.NuGet/SLSharp.nuspec" -outputDirectory bin/Release

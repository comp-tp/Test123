@echo off

%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /p:Configuration=SQLServer ".\Accela.Apps.Apis.Services.SQLServer.sln" /p:DeployOnBuild=true /p:PublishProfile="Build-SqlServer-Profile.pubxml" /p:VisualStudioVersion=12.0

DEL /S /Q ".\ReleasePackages\NonAzureHost\NLog.SQLServer.config"
DEL /S /Q ".\ReleasePackages\NonAzureHost\NLog.Azure.config"
DEL /S /Q ".\ReleasePackages\NonAzureHost\packages.config"

SET currentPath=%cd%\ReleasePackages\NonAzureHost

@echo Build is completed, please get release package from %currentPath%
@echo Done!
if %errorlevel% NEQ 0 goto end

:end
if [%1] NEQ [nopause] pause


@echo off

%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /t:Publish /p:TargetProfile=Cloud.apps /p:Configuration=Azure.Release /v:m Accela.Apps.Apis.Azure.sln /distributedFileLogger /p:VisualStudioVersion=14.0

if %errorlevel% NEQ 0 goto end

:end
if [%1] NEQ [nopause] pause

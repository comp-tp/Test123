
%windir%\system32\inetsrv\appcmd set config /section:applicationPools /applicationPoolDefaults.processModel.idleTimeout:00:00:00 >> "%TEMP%\StartupLog.txt" 2>&1
%windir%\system32\inetsrv\appcmd set config /section:applicationPools /applicationPoolDefaults.startMode:AlwaysRunning >> "%TEMP%\StartupLog.txt" 2>&1
%systemroot%\system32\inetsrv\AppCmd.exe list app /xml | %windir%\system32\inetsrv\appcmd set site /in -applicationDefaults.preloadEnabled:True

REM   ERRORLEVEL 183 occurs when trying to add a section that already exists. This error is expected if this
REM   batch file were executed twice. This can occur and must be accounted for in a Windows Azure startup
REM   task. To handle this situation, set the ERRORLEVEL to zero by using the Verify command. The Verify
REM   command will safely set the ERRORLEVEL to zero.
IF %ERRORLEVEL% EQU 183 DO VERIFY > NUL

REM   If the ERRORLEVEL is not zero at this point, some other error occurred.
IF %ERRORLEVEL% NEQ 0 (
   ECHO Error adding a section to the Web.config file. >> "%TEMP%\StartupLog.txt" 2>&1
   GOTO ErrorExit
)


REM   *** Exit batch file. ***
EXIT /b 0

REM   *** Log error and exit ***
:ErrorExit
REM   Report the date, time, and ERRORLEVEL of the error.
DATE /T >> "%TEMP%\StartupLog.txt" 2>&1
TIME /T >> "%TEMP%\StartupLog.txt" 2>&1
ECHO An error occurred during startup. ERRORLEVEL = %ERRORLEVEL% >> "%TEMP%\StartupLog.txt" 2>&1
EXIT %ERRORLEVEL%



@echo off

set version=%1

if "%version%"=="" (
  echo Please remember to specify which version to push as an argument.
  goto exit_fail
)

set reporoot=%~dp0\..
set destination=%reporoot%\deploy

if not exist "%destination%" (
  echo Could not find %destination%
  echo.
  echo Did you remember to build the packages before running this script?
)

set nuget=%reporoot%\tools\NuGet\NuGet.exe

if not exist "%nuget%" (
  echo Could not find NuGet here:
  echo.
  echo    "%nuget%"
  echo.
  goto exit_fail
)


"%nuget%" push "%destination%\*.%version%.nupkg" -Source https://www.nuget.org/api/v2/package
if %ERRORLEVEL% neq 0 (
  echo NuGet push failed.
  goto exit_fail
)

git tag %version%
git push --tags

goto exit



:exit_fail

echo An error occurred.
exit /b 1



:exit
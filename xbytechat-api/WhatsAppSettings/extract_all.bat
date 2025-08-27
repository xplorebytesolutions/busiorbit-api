@echo off
REM This script will find all files and output their name and content into one file.

set "outputFile=All_Content.txt"

REM Clear the output file to start fresh
> "%outputFile%" (echo Folder and File Content Report)
echo. >> "%outputFile%"

REM Loop through all files in the current directory and subdirectories
for /R . %%F in (*.*) do (
    echo ====================================================== >> "%outputFile%"
    echo FILE: %%F >> "%outputFile%"
    echo ====================================================== >> "%outputFile%"
    echo. >> "%outputFile%"
    type "%%F" >> "%outputFile%"
    echo. >> "%outputFile%"
    echo. >> "%outputFile%"
)

echo Finished! All content has been extracted to %outputFile%
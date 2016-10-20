::

:: %1: project dir
:: %2: debug release
:: %3: solution dir

"%1..\external\Microsoft Ajax Minifier\ajaxmin.exe" "%1bin\%2\Saltarelle.Utils.js" -out "%1bin\%2\Saltarelle.Utils.min.js" -clobber

::**********************************************************
:: copy output to ..\..\lib
::**********************************************************
del "%1..\..\lib\*.*" /f /q /s
copy "%1bin\%2\Saltarelle.Utils.js" "%1..\..\lib\saltarelle.utils.js"
copy "%1bin\%2\Saltarelle.Utils.min.js" "%1..\..\lib\saltarelle.utils.min.js"
copy "%1bin\%2\Saltarelle.Utils.dll" "%1..\..\lib\Saltarelle.Utils.dll"



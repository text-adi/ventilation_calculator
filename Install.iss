[Setup]
AppName=Автоматизована система підрахунку вентиляції
AppVersion=1.0
DefaultDirName={pf}\Calculator Vantilator

[Files]
Source: "bin\Debug\net6.0-windows\*"; DestDir: "{app}"
Source: "bin\Debug\net6.0-windows\runtimes\win-x64\native\e_sqlite3.dll"; DestDir: "{app}\runtimes\win-x64\native\"
Source: "bin\Debug\net6.0-windows\runtimes\win-x86\native\e_sqlite3.dll"; DestDir: "{app}\runtimes\win-x86\native\"
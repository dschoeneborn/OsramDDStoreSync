# OsramDDStoreSync
This application allows you to synchronize a defined folder with the Osram Cloud for driver data. It is based on a Windows service.

## Features
Searches every x (is customizable) milliseconds for new driver data xml files. The API of the DDStore service is used for this (https://tuner4tronic.com/ddstore/). The folder to be synchronized is also customizable.

## Installatin
1. Download prefered version from https://github.com/dschoeneborn/OsramDDStoreSync/releases
2. Copy files from zip to installation directory (e.g. C:\Programm Files(x86)\OsramDDStoreSync\)
3. Open CMD and navigate to folder
4. Install the service with 'installutil OsramDDStoreSync.exe'
5. Restart your PC or start the service manually

## Customizing
tbd

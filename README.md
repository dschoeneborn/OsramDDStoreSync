# OsramDDStoreSync
This application allows you to synchronize a defined folder with the Osram Cloud for driver data. It is based on a Windows service.

## Features
Searches every x (is customizable) milliseconds for new driver data xml files. The API of the DDStore service is used for this (https://tuner4tronic.com/ddstore/). The folder to be synchronized is also customizable.

## Installation
1. Download prefered version from https://github.com/dschoeneborn/OsramDDStoreSync/releases
2. Copy files from zip to installation directory (e.g. C:\Programm Files(x86)\OsramDDStoreSync\)
3. Open CMD and navigate to folder
4. Install the service with `installutil OsramDDStoreSync.exe` or `OsramDDStoreSync.exe --install` or Setup.exe
5. Restart your PC or start the service manually

## Customizing
The Service is customizeable by Config-File 'OsramDDStoreSync.exe.config'.

```xml
<add key="EnableGraylog" value="true"/>
<add key="GraylogHost" value="192.168.0.2"/>
<add key="GraylogPort" value="12201"/>
<add key="DriverDataPath" value="C:\Program Files (x86)\T4T\ECGs" />
<add key="FamilyDataPath" value="C:\Program Files (x86)\T4T\Family" />
<add key="CheckInterval" value="1800000"/> <!--In ms-->
```

### EnableGraylog
Defines wheter certain events should be written to a Graylog system.

### GraylogHost
IP or hostname of the Graylog system.

### GraylogHost
Port of the Graylog input.

### DriverDataPath
Path to the folder where the driver data is located. This is usually `C:\Program Files (x86)\T4T\ECGs`.

### FamilyDataPath
Path to the folder where the family data is located. This is usually `C:\Program Files (x86)\T4T\Family`.

### CheckInterval
The interval at which the service checks for updates. Specified in milliseconds.

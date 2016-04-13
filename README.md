# sharpberry
> Projekt with .Net C-Sharp on a Raspberry Pi

# Vorgehen Installation
1. Download IoT Dashboard von https://developer.microsoft.com/en-us/windows/iot/GetStarted.htm
2. IoT Dashboard Tool Ausführen und Windows IOT auf Flash Karte installieren
3. Flash Karte in Raspberry stecken und booten (Dauert das 1. mal ziemlich lange)


# .Net Projekt (13.04.2016)
**Informationen**
- Windows IoT Core Project Templates für VS2015 herunterladen https://visualstudiogallery.msdn.microsoft.com/55b357e1-a533-43ad-82a5-a88ac4b01dec
- Samples usw zu finden unter: https://github.com/ms-iot

**Projekt erstellen**
- neues c# Proekt "Windows iot Core"
- Universal Windows Target Version 10.0; Build 10586
- Referenz hinzufügen "Windows IoT Extensions for the UWP" in Version 10586 https://blogs.msdn.microsoft.com/cdndevs/2015/05/08/windows-10-how-to-use-iot-extension-for-raspberry-pi-2-part-1/

**Windows IOT**
Standard Login ist:
administrator
p@ssw0rd

***Zugriff per web UI***
IP:8080


***Zugriff per PowerShell:***
https://ms-iot.github.io/content/en-US/win10/samples/PowerShell.htm

NOTE: you may need to start the WinRM service on your desktop to enable remote connections. From the PS console type the following command:
`net start WinRM`

From the PS console, type the following, substituting <machine-name or IP Address> with the appropriate value (using your machine-name is the easiest to use, but if your device is not uniquely named on your network, try the IP address):
`Set-Item WSMan:\localhost\Client\TrustedHosts -Value <machine-name or IP Address>
Do enter Y to confirm the change.`

NOTE: If you want to connect multiple devices, you can use comma and quotation marks to separate each devices.
`Set-Item WSMan:\localhost\Client\TrustedHosts -Value "<machine1-name or IP Address>,<machine2-name or IP Address>"`

Now you can start a session with your Windows IoT Core device. From you administrator PS console, type:
`Enter-PSSession -ComputerName <machine-name or IP Address> -Credential <machine-name or IP Address or localhost>\Administrator`

In the credential dialog enter the following default password: p@ssw0rd

NOTE: The connection process is not immediate and can take up to 30 seconds.

# echo the IIS log to the console:
Start-Service W3SVC 
Invoke-WebRequest http://localhost -UseBasicParsing | Out-Null
netsh http flush logbuffer | Out-Null
Get-Content -path 'c:\iislog\W3SVC\u_extend1.log' -Tail 1 -Wait 
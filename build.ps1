cp src\NotificationsService\bin\Release\* -Destination (New-Item "docker\notifications-service\NotificationService\" -Type container -Force)  -Force
cp src\ProcessingService\bin\Release\* -Destination (New-Item "docker\processing-service\ProcessingService\" -Type container -Force)  -Force
cp src\NotesWeb\bin\* -Destination (New-Item "docker\notes-web\NotesWeb\" -Type container -Force) -Force
write-host "copying items"
cp src\NotificationsService\bin\Release\* -Destination (New-Item "docker\notifications-service\NotificationsService\" -Type container -Force)  -Force
cp src\ProcessingService\bin\Release\* -Destination (New-Item "docker\processing-service\ProcessingService\" -Type container -Force)  -Force
#cp src\NotesWeb\bin\* -Destination (New-Item "docker\notes-web\NotesWeb\" -Type container -Force) -Force

write-host "building containers"
docker image build docker/notes-web --tag dockernotes/notes-web
docker image build docker/notifications-service --tag dockernotes/notifications-service
docker image build docker/processing-service --tag dockernotes/processing-service

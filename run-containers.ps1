write-host "removing containers"
docker rm -f notesqueue
docker rm -f notifications
docker rm -f ps
docker rm -f nw

write-host "notesqueue:"
docker container run -d --net mynet --name notesqueue nats

write-host "notifications:"
docker container run -d  -p:1234:1234 --net mynet --name notifications dockernotes/notifications-service

write-host "ps:"
docker container run -d --net mynet --name ps dockernotes/processing-service

write-host "nw:"
docker container run -d --net mynet -p:80:80 --name nw dockernotes/notes-web


docker container ls

docker inspect --format '{{ .NetworkSettings.IPAddress }}' nw
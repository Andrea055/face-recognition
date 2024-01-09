# Face recognition with Dotnet working with Linux and MacOS using Docker

## Client
This project use Docker so if you haven't you can install it [Debian]

```bash
    sudo apt install docker.io
```

Clone the project from GitHub: 

```bash
    git clone https://github.com/andreock/face-recognition.git
```

To start it [you have to change the path with your name]:

```bash
    docker build --tag YourName/face_recognition - < Dockerfile
    docker run -it -d -v /tmp/.X11-unix:/tmp/.X11-unix -v /dev/shm:/dev/shm  --device /dev/dri --device=dev/video0:/dev/video0 -e DISPLAY=:0 -p 2222:22 -v /dev/video0:/dev/video0 YourName/face_recognition /bin/bash
```
[in case of error remove the string ```--device /dev/dri```]

Now we have to add docker to group to running it without root:

```bash
    sudo usermod -aG docker $USER
```

Then you can open an ssh session at localhost:2222 and start the program at /home/dev/face-recognition/FaceRecognition [the password for ssh is qwe123]: 

```bash
    ssh root@localhost -p 2222
```

## Web Server
Required things:
 - MySQL
 - DotNet 6

**IMPORTANT** : create a user in database for the project and insert the userID and password in ```FaceRecognitionPanel/DBContext/Model.cs```. 

Create the database's scaffholding 
```bash
    dotnet ef database update
```

Run both server and client project
```bash
    dotnet run
```

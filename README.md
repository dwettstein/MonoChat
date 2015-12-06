## MonoChat
A simple chat application using the frameworks Mono (http://www.mono-project.com/) and Akka.NET (http://getakka.net/).

### Functionalities:
- Server is the chat room.
- Clients can connect to the server (chat room) with their user's name.
- Clients can see which other users are currently online.
- Clients are able to export the current chat session to their OneDrive account using OAuth (only on client side).

### Properties:
- DB: We will not use any DB. The chat messages are delivered by the server to all connected clients (broadcast). If the client wants to save the chat session, he will be able to export it to his OneDrive account (https://dev.onedrive.com/).
- There will be only one role (the user).
- For connecting to the chat there will be no authentication (only the name).
- UI: The UI will be implemented with Mono compatible libraries (Mono uses C# as programming language => desktop applications, see http://www.mono-project.com/).
- The server and also the client will be implemented with the Mono framework. As a result, the server will be able to run on a Windows or Linux OS.

### System requirements:
#### Windows:
Nothing special.

#### Linux:
Quick guide for Debian, Ubuntu, and derivatives (for other distributions see here: [Install Mono on Linux](http://www.mono-project.com/docs/getting-started/install/linux/)):
> Add the Mono Project GPG signing key and the package repository to your system (if you don’t use sudo, be sure to switch to root):
```bash
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get update
sudo apt-get upgrade
```
Install Mono:
```bash
sudo apt-get mono-complete
```

### How to run the server:
Info: The server will run on port 8081.

#### Windows:
1. Open command window in folder with server binary
2. Launch `ChatServer.exe` with the IP address or hostname as parameter (allow Windows Firewall access if prompted):
```cmd
ChatServer.exe 192.168.1.2
```
or
```cmd
ChatServer.exe your-hostname
```

#### Linux:
1. Open command window in folder with server binary
2. Launch `ChatServer.exe` with the IP address or hostname as parameter:
```bash
mono ChatServer.exe 192.168.1.2
```
or
```bash
mono ChatServer.exe your-hostname
```

### How to run the client:
Info: The client will run on any free port.

#### Windows:
1. Double-click on the binary `WebEng_Chat.exe` and follow instructions.

#### Linux:
1. Right-click on `WebEng_Chat.exe` and run with Mono or open command window in folder with client binary and launch with:
```bash
mono WebEng_Chat.exe
```

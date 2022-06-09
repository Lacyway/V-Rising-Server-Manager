# V Rising Server Manager

## Information
Tool to install, update and run a V Rising Server on Windows OS. Also includes a game and server settings editor.


## Usage
### Installation
Read the [Wiki](https://github.com/Lacyway/V-Rising-Server-Manager/wiki/Initial-Setup) for more info.

Download the latest [release](https://github.com/Lacyway/V-Rising-Server-Manager/releases).

Extract the files to any folder. Run the program and go to 'Settings' and set up each entry.
If you have already installed a VRising Server you can point it to that folder. If not, when you are done click 'Update Game Server' and wait for SteamCMD to finish downloading the game.

Press 'Start Game Server' to start the game server.

### Settings Editor
You can change the settings file using the 'Editors' on the right. Either load one or create a new one by filling the fields and then saving it to the save folder.
Example: `VRising\Saves\Saves\v1\world1\ServerGameSettings.json` or `VRising\Saves\Saves\v1\world1\ServerHostSettings.json`

### RCON
The application has a very primitive RCON console built in. If you have RCON enabled in your ServerHostSettings you can connect to it and run the commands on the right. Currently only 2 commands are implemented in the game.

Select a command and write the parameter in the text field at the bottom and click 'Send' to send the command to the server. No need to write the command.

## Requirements
Needs [.NET Runtime 6.0](https://download.visualstudio.microsoft.com/download/pr/5681bdf9-0a48-45ac-b7bf-21b7b61657aa/bbdc43bc7bf0d15b97c1a98ae2e82ec0/windowsdesktop-runtime-6.0.5-win-x64.exe)

If you wish to compile it use the [.NET 6.0 SDK, Visual Studio 22](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

Libraries used:
- Newtonsoft.Json
- source-rcon-server

## Pictures

<img src="https://i.imgur.com/RSkccw8.png" width="400">
<img src="https://i.imgur.com/P4uZFoR.png" width="200">
<img src="https://i.imgur.com/hAOgfxd.png" width="400">
<img src="https://i.imgur.com/vNB86zM.png" width="400">
<img src="https://i.imgur.com/JqRlHP0.png" width="200">

## Note
This is my first C# project. It's probably not made in the best way, please be constructive.

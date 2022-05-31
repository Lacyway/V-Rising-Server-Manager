# V Rising Settings Editor

## Information
Tool to install, update and run a V Rising Server on Windows. Also includes a game and server settings editor.

Made for Windows.

## Usage
### Installation
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

Libraries used:
- Newtonsoft.Json
- source-rcon-server

## Note
This is my first C# project. It's probably not made in the best way, please be constructive.

# V Rising Server Manager

## Information
Tool to install, update and run a V Rising Server on Windows OS. Also includes a game and server settings editor.


## Usage
### Installation
Read the [Wiki](https://github.com/Lacyway/V-Rising-Server-Manager/wiki/Initial-Setup) for more info.

Download the latest [release](https://github.com/Lacyway/V-Rising-Server-Manager/releases).

Extract the files to any folder. Run the program.

### Settings Editor
You can change the settings file using the 'Editors' on the right. Either load one or create a new one by filling the fields and then saving it to the save folder.
Example: `SaveData\Settings\ServerGameSettings.json` or `SaveData\Settings\ServerHostSettings.json`

### RCON
The application has a very primitive RCON console built in. If you have RCON enabled in your ServerHostSettings you can connect to it and run the commands on the right. Currently only 2 commands are implemented in the game.

Select a command and write the parameter in the text field at the bottom and click 'Send' to send the command to the server. No need to write the command.

## Requirements
Needs [.NET Runtime 6.0](https://download.visualstudio.microsoft.com/download/pr/5681bdf9-0a48-45ac-b7bf-21b7b61657aa/bbdc43bc7bf0d15b97c1a98ae2e82ec0/windowsdesktop-runtime-6.0.5-win-x64.exe)

If you wish to compile it use the [.NET 6.0 SDK, Visual Studio 22](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

Libraries used
- source-rcon-server
- ModernWPF

## Pictures

<img src="https://raw.githubusercontent.com/Lacyway/V-Rising-Server-Manager/master/Resources/mainwindow.png" width="400">
<img src="https://raw.githubusercontent.com/Lacyway/V-Rising-Server-Manager/master/Resources/adminmanager.png" width="200">
<img src="https://raw.githubusercontent.com/Lacyway/V-Rising-Server-Manager/master/Resources/rconconsole.png" width="400">
<img src="https://raw.githubusercontent.com/Lacyway/V-Rising-Server-Manager/master/Resources/gamesettingseditor.png" width="400">
<img src="https://raw.githubusercontent.com/Lacyway/V-Rising-Server-Manager/master/Resources/serversettingseditor.png" width="200">

## Note
This is my first C# project. It's probably not made in the best way, please be constructive.

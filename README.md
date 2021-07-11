# CutieCore (PC Only) [![Build](https://github.com/Goobwabber/CutieCore/workflows/Build/badge.svg?event=push)](https://github.com/Goobwabber/CutieCore/actions?query=workflow%3ABuild+branch%3Amain)
Cutest beatsaber mod

## Features (Features require optional mods)
* Modifies the action button
* Forces color scheme without you asking
* [CustomMenuText](https://github.com/headassbtw/CustomMenuText)
* [HitScoreVisualizer](https://github.com/ErisApps/HitScoreVisualizer)
* Multiplayer Player Places - requires [MultiplayerExtensions](https://github.com/Goobwabber/MultiplayerExtensions)
* Various Assorted Coloring - requires [DiColors](https://github.com/Auros/DiColors)

## Installation
1. Ensure you have the [required mods](https://github.com/Goobwabber/CutieCore#requirements)
2. Download the `CutieCore` file listed under `Assets` **[Here](https://github.com/Goobwabber/CutieCore/releases)**.
    * Optionally, you can get a development build by downloading the file listed under `Artifacts` **[Here](https://github.com/Goobwabber/CutieCore/actions?query=workflow%3ABuild+branch%3Amain)** (pick the topmost successful build).
    * You must be logged into GitHub to download a development build.
3. Extract the zip file to your Beat Saber game directory (the one `Beat Saber.exe` is in).
    * The `CutieCore.dll` (and `CutieCore.pdb` if it exists) should end up in your `Plugins` folder (**NOT** the one in `Beat Saber_Data`).
4. **Optional**: Edit `Beat Saber IPA.json` (in your `UserData` folder) and change `Debug` -> `ShowCallSource` to `true`. This will enable BSIPA to get file and line numbers from the `PDB` file where errors occur, which is very useful when reading the log files. This may have a *slight* impact on performance.

## Requirements
These can be downloaded from [BeatMods](https://beatmods.com/#/mods) or using Mod Assistant. **Do NOT use any of the DLLs in the `Refs` folder, they have been stripped of code and will not work.**
* BeatSaberMarkupLanguage v1.4.5+
* SiraUtil v2.4.0+
* DiColors v1.0.4+ **OPTIONAL**
* MultiplayerExtensions v0.5.4+ **OPTIONAL**
* CustomMenuText v3.4.0+ **OPTIONAL**
* HitScoreVisualizer v3.1.0+ **OPTIONAL**

## Reporting Issues
* The best way to report issues is to click on the `Issues` tab at the top of the GitHub page. This allows any contributor to see the problem and attempt to fix it, and others with the same issue can contribute more information. **Please try the troubleshooting steps before reporting the issues listed there. Please only report issues after using the latest build, your problem may have already been fixed.**
* Include in your issue:
  * A detailed explanation of your problem (you can also attach videos/screenshots)
  * **Important**: The log file from the game session the issue occurred (restarting the game creates a new log file).
    * The log file can be found at `Beat Saber\Logs\_latest.log` (`Beat Saber` being the folder `Beat Saber.exe` is in).
* If you ask for help on Discord, at least include your `_latest.log` file in your help request.

## Contributing
Anyone can feel free to contribute bug fixes or enhancements to CutieCore. GitHub Actions for Pull Requests made from GitHub accounts that don't have direct access to the repository will fail. This is normal because the Action requires a `Secret` to download dependencies.
### Building
Visual Studio 2019 with the [BeatSaberModdingTools](https://github.com/Zingabopp/BeatSaberModdingTools) extension is the recommended development environment.
1. Check out the repository
2. Open `CutieCore.sln`
3. Right-click the `CutieCore` project, go to `Beat Saber Modding Tools` -> `Set Beat Saber Directory`
   * This assumes you have already set the directory for your Beat Saber game folder in `Extensions` -> `Beat Saber Modding Tools` -> `Settings...`
   * If you do not have the BeatSaberModdingTools extension, you will need to manually create a `CutieCore.csproj.user` file to set the location of your game install. An example is showing below.
4. The project should now build.

**Example csproj.user File:**
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <BeatSaberDir>Full\Path\To\Beat Saber</BeatSaberDir>
  </PropertyGroup>
</Project>
```
## Donate
You can support development of CutieCore by donating at the following links:
* https://ko-fi.com/goobwabber

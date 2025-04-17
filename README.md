# neon-dreams

A JRPG written in C# with no true game engine. Due to not having **Steamworks** setup for this game, **Steamworks** does exist in the source code and in the binary directory but remains mostly unused.

# Dependencies

> [*Raylib-CS*]() - C# bindings for [*Raylib 5.5*](https://github.com/raysan5/raylib)

> [*MoonSharp*](https://github.com/moonsharp-devs/moonsharp) - A pure C# solution to [*Lua*](https://lua.org/)

> [*Steamworks.NET*](https://steamworks.github.io/) - C# bindings for [*Steamworks*](https://github.com/rlabrecque/SteamworksSDK)

# How to Build

This project cannot be compiled with or `dotnet run` right out of the box, it will fail to run. To build this project, you'll need to execute the build-script that is relevant to your operating system.

## Prerequisites

To build NeonDreams, you will *need* the following:
- .NET SDK Version 9.0 or greater
- Lua 5.1 or the latest Lua 5.x

## To install Prerequisites on Windows

**Dotnet SDK:**
 - [Download](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) the SDK for Windows x64
 - [Download](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) the SDK for Windows on ARM

**Lua 5.X:**
 - [Download](https://luabinaries.sourceforge.net/) the SDK via LuaBinaries
 - [Build](https://lua.org/ftp/) Lua from the source code

## To install Prerequisites on Linux

### Dotnet SDK
**Via Binary:**
 - Refer to the official link for the [proper binaries](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

**Via package manager:**
 - Microsoft provides instructions to install through your [package manager](https://learn.microsoft.com/en-ca/dotnet/core/install/linux?WT.mc_id=dotnet-35129-website)

**From source:**
 - I can't provide these instrucions, I would recommend their [GitHub](https://github.com/dotnet)

### Lua
**Package manager:**
 - `sudo apt install lua -y`
 - `sudo rpm install lua`
 - `pacman -S lua --noconfirm`

**Build from source:**
 - Download the [source](https://lua.org/ftp/) and follow provided instructions

## To install Prerequisites on MacOS

I recommend the `homebrew` package manager. This is *the* package manager for MacOS systems. Use the below `curl` command to fetch and run the install script from the repository.

> `/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"`

Once brew is insalled, run `brew install lua` and grab the [dotnet binary](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) from the binaries page, `brew` does not have a dotnet package to avail of.

## For Windows (x64 / arm64)

To build on Windows, you'll first need to check your *Powershell Execution Policy.* This policy is some security from Microsoft that disallows some PS1 scripts to be run on the users computer, just running `.\buildx64.ps1` or `.\buildarm64.ps1` will likely raise an error. To allow these files to run, you can change your execution policy. To double check your current policies, run `Get-ExecutionPolicy -List`, you should get an output like this:
```
        Scope ExecutionPolicy
        ----- ---------------
MachinePolicy       Undefined
   UserPolicy       Undefined
      Process       Undefined
  CurrentUser    RemoteSigned
 LocalMachine       Undefined
```

To modify the policy for `CurrentUser` or whichever you choose to modify, you can run either of these commands;

> `Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope []`

> `Set-ExecutionPolicy -ExecutionPolicy Bypass -Scope []`

For security reasons, `CurrentUser` or `UserPolicy` scopes are the best, it is **highly advised that you do not set `Bypass` to `MachinePolicy` as this is a massive security issue.**

Build scripts for Batch will not be provided, Powershell is required.

## For Linux (x64)

To build on Linux, you'll want to set the execution bit on the shell script.

> `chmod +x buildx64.sh`

From there, just run the shell script as one usually does and the project should be built in a few seconds. If errors are encountered, feel free to fixup the script as you need.

<!-- Intel Macs are not supported at this time -->
## For Apple Silicon MacOS

To build on MacOS, you'll want to set the execution bit on the **command** script.

> `chmod +x build_osx.sh`

From there, just run the script as one usually does and the project should start building. If errors are encountered, feel free to fixup the script as you need.

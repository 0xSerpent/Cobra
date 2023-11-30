using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Commands
{
    public static class UACCheck
    {
        public static async Task Run(SocketUserMessage msg, string[] parameters)
        {
            string processName = parameters[0];

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C reg query HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v EnableLUA",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                await process.WaitForExitAsync();

                string output = await process.StandardOutput.ReadToEndAsync();
                bool hasUAC = output.Contains("0x1");

                SerpentEmbed serpentEmbed = new SerpentEmbed();
                Embed embed = serpentEmbed.GetEmbed(hasUAC ? SerpentEmbeds.Success : SerpentEmbeds.Error, "UAC Check", $"The process {processName} {(hasUAC ? "has" : "does not have")} UAC enabled.");
                await msg.Channel.SendMessageAsync(embed: embed);
            }
        }
    }
}

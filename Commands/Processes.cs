using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Commands
{
    public static class Processes
    {
        public static async Task Run(SocketUserMessage message, string[] args)
        {
            Process[] processes = Process.GetProcesses();
            StringBuilder processList = new StringBuilder();

            for (int i = 0; i < processes.Length; i++)
            {
                Process currentProcess = processes[i];
                string name = currentProcess.ProcessName;

                if (processList.ToString().Contains(name))
                    continue;

                processList.AppendLine($"> {i}. ``{name}.exe``");
            }

            ButtonBuilder pinButton = new ButtonBuilder()
                .WithStyle(ButtonStyle.Primary)
                .WithCustomId("pin_msg")
                .WithLabel("📌");

            ButtonBuilder deleteButton = new ButtonBuilder()
                .WithStyle(ButtonStyle.Danger)
                .WithCustomId("delete_msg")
                .WithLabel("❌");

            Embed embedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success, "Processes", processList.ToString());

            await message.ReplyAsync(embed: embedToSend, components: new ComponentBuilder()
                .WithButton(pinButton)
                .WithButton(deleteButton)
                .Build());
        }
    }
}

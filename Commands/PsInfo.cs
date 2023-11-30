using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Commands
{
  public static class PsInfo
  {
    public static async Task Run(SocketUserMessage message, string[] args)
    {
      int index = Convert.ToInt32(args[0]);
      Console.WriteLine(index);

      Process[] processes = Process.GetProcesses();
      Process process = processes[index];

      string name = process.ProcessName;
      string id = $"{process.Id}";

      ButtonBuilder pinButton = new ButtonBuilder()
        .WithStyle(ButtonStyle.Primary)
        .WithCustomId("pin_msg")
        .WithLabel("📌");

      ButtonBuilder deleteButton = new ButtonBuilder()
        .WithStyle(ButtonStyle.Danger)
        .WithCustomId("delete_msg")
        .WithLabel("❌");

      string threadCount = $"{process.Threads.Count}";

      Embed embedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success, "Process info", $"> Name: ``{name}``\n> PID: ``{id}``\n> Threads: ``{threadCount}``");

      await message.ReplyAsync(embed: embedToSend, components: new ComponentBuilder().WithButton(pinButton).WithButton(deleteButton).Build());
    }
  }
}

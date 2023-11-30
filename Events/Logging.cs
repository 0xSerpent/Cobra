using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Events
{
    public static class Logging
    {
        public static Task Log(LogMessage msg)
        {
            Console.WriteLine($"Log: {msg}");
            return Task.CompletedTask;
        }

        public static Task Ready()
        {
            Console.WriteLine("Serpent is ready.");
            return Task.CompletedTask;
        }

        public static async Task HandleInteractions(dynamic component)
        {
            if (component is SocketMessageComponent interaction)
            {
                await interaction.DeferAsync();

                switch (interaction.Data.CustomId)
                {
                    case "pin_msg":
                        await interaction.Message.PinAsync();
                        break;

                    case "delete_msg":
                        await interaction.Message.DeleteAsync();
                        break;

                    case "unpin_msg":
                        await interaction.Message.UnpinAsync();
                        break;
                }
            }
        }
    }
}

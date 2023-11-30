using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Commands
{
    public static class HelpCmd
    {
        public static async Task Run(SocketUserMessage message, string[] args)
        {
            await message.ReplyAsync("help cmd!!!");
        }
    }
}
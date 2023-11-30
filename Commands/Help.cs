using Discord;
using Discord.WebSocket;

namespace Commands {

    public static class HelpCmd {

        public static async Task Run(SocketUserMessage Message,string[] args) { // args being the NON joint arguments. its not needed here since its a simple help.

        await Message.ReplyAsync("help cmd!!!");



        }

    }
}
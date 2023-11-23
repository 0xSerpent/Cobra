using System;
using Discord;
using Discord.WebSocket;

namespace Events
{


    public static class Logging {

    public static  Task Log(LogMessage Msg) {

        Console.WriteLine($"Log : {Msg.ToString()}");
        return Task.CompletedTask;
    }

    public static Task Ready() {
        Console.WriteLine("Serpent is ready.");
        
        return Task.CompletedTask;
    }

    public static async Task HandleInteractions(dynamic component) {

             if (component is SocketMessageComponent Interaction)
            {
                
                
                switch (Interaction.Data.CustomId) {

                    case "pin_msg":

                    await Interaction.DeferAsync();

                    await Interaction.Message.PinAsync();
                    break;

                    case "delete_msg":
                    await Interaction.DeferAsync();

                    await Interaction.Message.DeleteAsync();
    

                    break;

                    case "unpin_msg":
                    
                    await Interaction.DeferAsync();
                    await Interaction.Message.UnpinAsync();

                    break;

                }
                if (Interaction.Data.CustomId == "pin_msg") {

                    await Interaction.DeferAsync();

                    await Interaction.Message.PinAsync();
                


            }

       

            }
            
        
        
    }


  
    


};

    
}

using System.Diagnostics;
using Discord;
using Discord.WebSocket;
using Helper;

namespace Commands {
    public static class PsInfo {


            public static async Task Run(SocketUserMessage Message, string[] args) {
                

              //  Dictionary<int,Process> PS = new Dictionary<string, string>();

                int index = Convert.ToInt32(args[0]);

                Console.WriteLine(index);

                Process[] ps = Process.GetProcesses();

                Process p = ps[index];

                

                string Name = p.ProcessName;
                string ID = $"{p.Id}";
                ButtonBuilder PINbutton =  new ButtonBuilder();
                ButtonBuilder DButton = new ButtonBuilder();
                PINbutton
                .WithStyle(ButtonStyle.Primary)
                .WithCustomId("pin_msg")
                .WithLabel("📌");

                 DButton
                .WithStyle(ButtonStyle.Danger)
                .WithCustomId("delete_msg")
                .WithLabel("❌");

                


        
                string ThreadCount = $"{p.Threads.Count}";
               
                
            
                
                
                Embed EmbedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success,$"Process info" , $"> Name : ``{Name}``\n> PID : ``{ID}``\n> Threads : ``{ThreadCount}``");
                
                await Message.ReplyAsync(embed : EmbedToSend,components: new ComponentBuilder().WithButton(PINbutton).WithButton(DButton).Build());
               
               


                
            }

            
        }
    }

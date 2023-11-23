using System.Diagnostics;
using Discord;
using Discord.WebSocket;
using Helper;

namespace Commands {
    public static class ZProcesses {


            public static async Task Run(SocketUserMessage Message, string[] args) {
                

              //  Dictionary<int,Process> PS = new Dictionary<string, string>();

               Process[] ps = Process.GetProcesses();
               string psSTR = "";
                for (int i = 0; i < ps.Length; i++)
                {
                    Process CurrPs = ps[i];
                    string Name = CurrPs.ProcessName;
                    string Final = $"> {i}. ``{Name}.exe``\n";
                    
                   if (psSTR.Contains(Name)) continue;
                    psSTR += Final;
                }
            

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

                
                
                Embed EmbedToSend = new SerpentEmbed().GetEmbed(SerpentEmbeds.Success,$"Processes" , $"{psSTR}");
                await Message.ReplyAsync(embed : EmbedToSend , components : new ComponentBuilder().WithButton(PINbutton).WithButton(DButton).Build());

                
            }

            
        }
    }

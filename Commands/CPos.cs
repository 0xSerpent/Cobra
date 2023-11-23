using System.Diagnostics;
using Discord;
using Discord.WebSocket;
using System.Runtime.InteropServices;
namespace Commands {
    public static class CPos {



            



            [DllImport("user32.dll")]
            public static extern bool SetCursorPos(int x, int y);

            public static async Task Run(SocketUserMessage Message, string[] args) {
                
            int x = Convert.ToInt32(args[0]);
            int y = Convert.ToInt32(args[1]);


            SetCursorPos(x , y);
            

              
            
        }
    }

}
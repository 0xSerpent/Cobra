using System.Diagnostics;
using Discord;
using Discord.WebSocket;
using System.Runtime.InteropServices;
namespace Commands {
    public static class Messagebox {



            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);



            public static async Task Run(SocketUserMessage Message, string[] args) {
                
            string text = args[0];
            string caption = args[1];
            Thread t = new Thread(() => {
                
                MessageBox(IntPtr.Zero,text,caption,(uint)0x00000030L);


            });

            t.Start();
            

              
            
        }
    }

}
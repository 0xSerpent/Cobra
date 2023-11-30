using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Commands
{
    public static class Messagebox
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        public static async Task Run(SocketUserMessage message, string[] args)
        {
            string text = args[0];
            string caption = args[1];

            await Task.Run(() =>
            {
                MessageBox(IntPtr.Zero, text, caption, 0x00000030);
            });
        }
    }
}
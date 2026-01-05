using System.Runtime.InteropServices;

namespace AutoClicker
{
    internal class AutoClicker
    {
        static void Main()
        {
            //Imports
            [DllImport("user32.dll")]
            static extern void mouse_event(uint dwFlags, uint dwX, uint dwY, uint dwData, IntPtr dwExtraInfo);

            [DllImport("user32.dll")]
            static extern short GetAsyncKeyState(int vKey);

            // Variables 

            const uint LeftDown = 0x02;
            const uint LeftUp = 0x04;
            const int Hotkey = 0x75; // https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

            bool enableClciker = false;
            int clickInterval = 5; // How faster the left key is pressed

            // Main loop 
            while (true)
            {
                if (GetAsyncKeyState(Hotkey) < 0)
                {
                    enableClciker = !enableClciker;

                    Thread.Sleep(300);
                }

                else if (enableClciker)
                {
                    Mouseclick();
                }
                Thread.Sleep(clickInterval);
            }

            // Mouse click 
            void Mouseclick()
            {
                mouse_event(LeftDown, 0, 0, 0, IntPtr.Zero);
                mouse_event(LeftUp, 0, 0, 0, IntPtr.Zero);
            }
        }
    }
}
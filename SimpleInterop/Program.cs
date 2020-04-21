

using System;
using System.Runtime.InteropServices;

namespace SimpleInterop
{
    class Program
    {
        [DllImport("user32")]
        extern static bool MessageBeep(uint sound);
        static void Main(string[] args)
        {
            MessageBeep(0x30);
        }
    }
}

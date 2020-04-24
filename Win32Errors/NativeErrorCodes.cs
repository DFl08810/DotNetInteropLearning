using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Win32Errors
{
    class NativeErrorCodes
    {
        //Handling errors without C# exception handling. Only returns number code 
        [DllImport("kernel32", SetLastError = true)]
        //Openthread gets handle to process
        static extern IntPtr OpenThread(uint access, bool ineritHandle, int io);

        const int SYNCHRONIZE = 0x00100000;
        static void Sec(string[] args)
        {
            Console.Write("Enter thread ID: ");
            int id = int.Parse(Console.ReadLine());
            var hThread = OpenThread(SYNCHRONIZE, false, id);
            if (hThread == IntPtr.Zero)
                Console.WriteLine($"Error: {Marshal.GetLastWin32Error()}");
            else
                Console.WriteLine("Opened handle successfully");
        }
    }
}

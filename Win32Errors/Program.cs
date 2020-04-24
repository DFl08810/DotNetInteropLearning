using System;
using System.Runtime.InteropServices;

namespace Win32Errors
{
    class Program
    {
        [DllImport("kernel32", EntryPoint = "OpenThread", SetLastError = true)]
        static extern IntPtr OpenThreadInternal(uint access, bool ineritHandle, int id);

        //Function OpenThread wraps pinvoke OpenThreadInternal function
        //If OpenThreadInternal retrieves error, function OpenThread will throw exception
        //We can use exception in try catch clause below and use it with normal C# error handling even if it comes from native code
        static IntPtr OpenThread(uint access, int id)
        {
            var handle = OpenThreadInternal(access, false, id);
            if (handle != IntPtr.Zero)
                return handle;
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            return IntPtr.Zero;
        }


        const int SYNCHRONIZE = 0x00100000;
        static void Main(string[] args)
        {
            Console.Write("Enter thread ID: ");
            int id = int.Parse(Console.ReadLine());
            
            try
            {
                var hThread = OpenThread(SYNCHRONIZE, id);
                Console.WriteLine("Opened handle successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

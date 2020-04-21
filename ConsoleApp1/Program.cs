using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter process ID: ");
            int pid = int.Parse(Console.ReadLine());
            var process = Process.GetProcessById(pid);
            bool is32bit = Is32BitProcess(process);
            Console.WriteLine("Proces {0} ({1}) is 32 bit: {2}",
                    process.ProcessName, pid, is32bit);
        }

        [DllImport("kernel32")]
        static extern bool IsWow64Process(IntPtr hProcess, out bool wow64);
        [DllImport("kernel32")]
        static extern void GetNativeSystemInfo(out SystemInfo si);

        static bool Is32BitProcess(Process process)
        {
            SystemInfo si;
            GetNativeSystemInfo(out si);
            bool isWow64process;
            IsWow64Process(process.Handle, out isWow64process);

            return si.wProcessorArchitecture == 0 ||
                si.wProcessorArchitecture == 9 && isWow64process;

        }
    }
}

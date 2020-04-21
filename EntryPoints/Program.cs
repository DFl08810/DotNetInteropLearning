using System;
using System.Runtime.InteropServices;

namespace EntryPoints
{
    class Program
    {
        //EntryPoint allows using function (in this case Sleep(msec)) to use custom alias => DoNothing.
        //Othervise it must be defined as in Windows API, or as defined in dll library in general
        [DllImport("kernel32", EntryPoint = "Sleep")]
        static extern void DoNothing(uint msec);
        //In windows API does not exist func CreateJobOjbect, there are A and W versions. Each has its difference, for example ANSI and Unicode string encoding are used by different version
        //ExactSpelling = true allows for calling desired function by name and ovverides heuristics. We have total controll which version of a function is called
        [DllImport("kernel32", ExactSpelling = true)]
        //
        static extern IntPtr CreateJobObjectW(IntPtr securityAttributes, string name);
        [DllImport("kernel32")]
        static extern bool CloseHandle(IntPtr handle);

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("waiting for a while...");
                DoNothing(2000);
                var newJob = CreateJobObjectW(IntPtr.Zero, "myjob");
                Console.WriteLine("Job handle: {0}", newJob);
                CloseHandle(newJob);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception error");
            }
        }
    }
}

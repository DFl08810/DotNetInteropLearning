using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace CallingConventions
{
    class Program
    {
        //Buffer must not be immutable, string in .NET is so e need to use StringBuilder
        //Calling convention allows to use calling convention from different language, in this case C

        [DllImport("msvcrt", CallingConvention = CallingConvention.StdCall)]
        extern static int sprintf(StringBuilder buffer, string format, int id);

        //fprintf is for writing to file
        [DllImport("msvcrt", CallingConvention = CallingConvention.StdCall)]
        extern static int fprintf(IntPtr fileName, string format, int id);

        //File IO with P/Invoke
        [DllImport("msvcrt", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        extern static IntPtr fopen(String filename, String mode);
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 fclose(IntPtr file);


        static void Main(string[] args)
        {
            //StringBuilder need to have allocated capacity for ex:(128)
            var buffer = new StringBuilder(128);
            sprintf(buffer, "Process %d is using sprintf", Process.GetCurrentProcess().Id);
            Console.WriteLine(buffer.ToString());

            //Logic for file IO
            IntPtr fileHandle = fopen("testFile.txt", "w+");
            fprintf(fileHandle, "Process %d is using sprintf", Process.GetCurrentProcess().Id);
            fclose(fileHandle);

            Console.WriteLine("file created successfully");
        }
    }
}

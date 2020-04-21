using System;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    //forces CLR to respect sequential order as written
    [StructLayout(LayoutKind.Sequential)]

    //_SYSTEM_INFO structure bridge from Sysinfoapi.h
    public struct SystemInfo
    {
        public ushort wProcessorArchitecture;
        public ushort wReserved;
        public uint dwPageSize;
        public IntPtr lpMinimumApplicationAddress;
        public IntPtr lpMaximumApplicationAddress;
        public IntPtr dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        public ushort wProcessorLevel;
        public ushort wProcessorRevision;
    }
}
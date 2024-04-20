using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace era_csharp.Game.Launch
{
    public static class Freeze69
    {

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        [DllImport("kernel32.dll")]
        private static extern uint SuspendThread(IntPtr hThread);

        public static void Freeze(this Process process)
        {

            foreach (object obj in process.Threads)
            {
                ProcessThread thread = (ProcessThread)obj;
                var Thread = OpenThread(2, false, (uint)thread.Id);
                if (Thread == IntPtr.Zero)
                {
                    break;
                }
                SuspendThread(Thread);
            }
        }
    }
}

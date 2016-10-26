using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PhoneBook
{
    internal static class SingleInstance
    {
        public static readonly int WmShowfirstinstance = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", ProgramInfo.AssemblyGuid);
        public const int WmSettext = 0x000C;
        static Mutex _mutex;

        public static bool Start()
        {
            bool onlyInstance;
            string mutexName = $"Local\\{ProgramInfo.AssemblyGuid}";

            // if you want your app to be limited to a single instance
            // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
            // string mutexName = String.Format("Global\\{0}", ProgramInfo.AssemblyGuid);

            _mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }

        public static void ShowFirstInstance(string arg)
        {
            WinApi.SendMessage(
                        (IntPtr)WinApi.HwndBroadcast,
                        WmSettext,
                        IntPtr.Zero,
                        arg);
        }
        public static void Stop()
        {
            _mutex.ReleaseMutex();
        }
    }
}
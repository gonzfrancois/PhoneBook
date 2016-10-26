using System;
using System.Runtime.InteropServices;

namespace PhoneBook
{
    internal static class WinApi
    {
        [DllImport("user32.dll")]
        private static extern int RegisterWindowMessage(string message);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int msg, IntPtr wparam, string lparam);

        public const int HwndBroadcast = 0xffff;

        public static int RegisterWindowMessage(string format, params object[] args) => RegisterWindowMessage(string.Format(format, args));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ghfnvtz
{
    internal static class WindowSetup
    {
        internal static void SetFont(short width, short height)
        {
            IntPtr hConsole = GetStdHandle(-11);

            var info = new CONSOLE_FONT_INFO_EX
            {
                cbSize = (uint)Marshal.SizeOf<CONSOLE_FONT_INFO_EX>(),
                FaceName = "Terminal",
                FontFamily = 0,
                FontWeight = 400,
                dwFontSize = new COORD
                {
                    X = width,
                    Y = height
                }
            };

            SetCurrentConsoleFontEx(hConsole, false, ref info);
        }

        internal static void EnableTrueColor()
        {
			var handle = GetStdHandle(-11);
			GetConsoleMode(handle, out uint mode);
			SetConsoleMode(handle, mode | 0x0004);
		}

		[DllImport("kernel32.dll")]
		static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

		[DllImport("kernel32.dll")]
		static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

		[DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CONSOLE_FONT_INFO_EX
        {
            public uint cbSize;
            public uint nFont;
            public COORD dwFontSize;
            public uint FontFamily;
            public uint FontWeight;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string FaceName;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct COORD
        {
            public short X;
            public short Y;
        }
    }
}

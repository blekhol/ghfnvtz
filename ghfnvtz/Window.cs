using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ghfnvtz
{
    internal class Window
    {
        private int width;
        private int height;

        private Dictionary<char, ConsoleColor> colors = new Dictionary<char, ConsoleColor>()
        {
            {'f' , ConsoleColor.Black },
            { 'F' , ConsoleColor.White },
            { 'k' , ConsoleColor.Blue },
			{ 'K' , ConsoleColor.DarkBlue },
			{ 'z' , ConsoleColor.Green },
			{ 'Z' , ConsoleColor.DarkGreen },
			{ 'c' , ConsoleColor.Cyan },
			{ 'C' , ConsoleColor.DarkCyan },
			{ 'p' , ConsoleColor.Red },
			{ 'P' , ConsoleColor.DarkRed },
			{ 'm' , ConsoleColor.Magenta },
			{ 'M' , ConsoleColor.DarkMagenta },
			{ 's' , ConsoleColor.Yellow },
			{ 'S' , ConsoleColor.DarkYellow },
			{ 'x' , ConsoleColor.Gray },
			{ 'X' , ConsoleColor.DarkGray },
		};

        public Window()
        {
        }

        public void Setup()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            WindowSetup.SetFont((short)8, (short)8);
            
            width = Console.LargestWindowWidth;
            height = Console.LargestWindowHeight;
			Console.SetBufferSize(width, height);
            Console.SetWindowSize(width, height);
        }

        public void DrawAtPos(char color)
        {
            Console.BackgroundColor = colors[color];
            Console.Write(" ");

			try
            {
				Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
			} catch { }
		}

        public void DrawLine((int, int) startPos, (int, int) endPos)
        {

        }
    }
}

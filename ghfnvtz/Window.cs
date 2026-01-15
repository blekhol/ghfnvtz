using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		Dictionary<char, string> colors = new()
		{
			{ 'f', "\x1b[48;2;0;0;0m " },
			{ 'F', "\x1b[48;2;255;255;255m " },

			{ 'k', "\x1b[48;2;0;120;215m " },
			{ 'K', "\x1b[48;2;0;0;128m " },

			{ 'z', "\x1b[48;2;16;124;16m " },
			{ 'Z', "\x1b[48;2;0;100;0m " },

			{ 'c', "\x1b[48;2;58;150;221m " },
			{ 'C', "\x1b[48;2;0;139;139m " },

			{ 'p', "\x1b[48;2;231;72;86m " },
			{ 'P', "\x1b[48;2;139;0;0m " },

			{ 'm', "\x1b[48;2;180;0;158m " },
			{ 'M', "\x1b[48;2;139;0;139m " },

			{ 's', "\x1b[48;2;249;241;165m " },
			{ 'S', "\x1b[48;2;184;134;11m " },

			{ 'x', "\x1b[48;2;204;204;204m " },
			{ 'X', "\x1b[48;2;105;105;105m " },
		};


		public Window()
		{
		}

		public void Setup()
		{
			Console.BackgroundColor = ConsoleColor.Black;

			WindowSetup.SetFont((short)8, (short)8);
			WindowSetup.EnableTrueColor();

			width = Console.LargestWindowWidth;
			height = Console.LargestWindowHeight;
			Console.SetBufferSize(width, height);
			Console.SetWindowSize(width, height);
		}

		public void DrawAtPos((int x, int y) pos, char colorCode)
		{
			Console.SetCursorPosition(pos.x, pos.y);

			Console.Write(colors[colorCode]);

			Console.SetCursorPosition(pos.x, pos.y);
		}

		public void DrawLine((int x, int y) start, (int x, int y) end, char colorCode)
		{
			if (start == end)
			{
				DrawAtPos(start, colorCode);
			}
			else
			{
				int xDistance = Math.Abs(end.x - start.x);
				int yDistance = Math.Abs(end.y - start.y);

				double length = Math.Sqrt(Math.Pow(xDistance, 2f) + Math.Pow(yDistance, 2f));

				double xStep = xDistance / length;
				double yStep = yDistance / length;

				int xDirection = 1;
				int xI = 0;
				int yDirection = 1;
				int yI = 0;

				if (Math.Min(start.x, end.x) == end.x)
				{
					xDirection = -1;
					xI = Convert.ToInt32(Math.Floor(length));
					int helper = start.x;
					start.x = end.x;
					end.x = helper;
					xStep *= -1;
				}
				if (Math.Min(start.y, end.y) == end.y)
				{
					yDirection = -1;
					yI = Convert.ToInt32(Math.Floor(length));
					int helper = start.y;
					start.y = end.y;
					end.y = helper;
					yStep *= -1;
				}

				for (int i = 0; i <= Convert.ToInt32(Math.Floor(length)); i++)
				{
					DrawAtPos((Convert.ToInt32(start.x + xDirection * (xI * xStep)), Convert.ToInt32(start.y + yDirection * (yI * yStep))), colorCode);
					xI += xDirection;
					yI += yDirection;
				}
				return;
			}
		}

		public void DrawRectangle((int x, int y) start, (int x, int y) end, char colorCode)
		{
			DrawLine(start, (end.x, start.y), colorCode);
			DrawLine((start.x, end.y), end, colorCode);
			DrawLine(start, (start.x, end.y), colorCode);
			DrawLine((end.x, start.y), end, colorCode);
		}
	}
}

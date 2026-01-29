using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghfnvtz
{
	internal class Window
	{
		public Dictionary<char, string> colors = new()
		{
			{ 'f', "\x1b[48;2;0;0;0m" },
			{ 'k', "\x1b[48;2;0;120;215m" },
			{ 'z', "\x1b[48;2;16;184;16m" },
			{ 'c', "\x1b[48;2;58;150;221m" },
			{ 'p', "\x1b[48;2;231;72;86m" },
			{ 'm', "\x1b[48;2;180;0;158m" },
			{ 's', "\x1b[48;2;249;241;165m" },
			{ 'x', "\x1b[48;2;204;204;204m" },

			{ 'F', "\x1b[48;2;255;255;255m" },
			{ 'K', "\x1b[48;2;0;0;128m" },
			{ 'Z', "\x1b[48;2;0;100;0m" },
			{ 'C', "\x1b[48;2;0;139;139m" },
			{ 'P', "\x1b[48;2;139;0;0m" },
			{ 'M', "\x1b[48;2;139;0;139m" },
			{ 'S', "\x1b[48;2;184;134;11m" },
			{ 'X', "\x1b[48;2;105;105;105m" },
		};
		
		Pixel[] windowState;

        public Window()
		{
		}

        public void Setup()
        {
			WindowSetup.SetFont(8, 8);
            WindowSetup.EnableTrueColor();

            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

			windowState = new Pixel[Console.LargestWindowWidth * Console.WindowHeight];

            for (int i = 0; i < windowState.Length; i++)
            {
				windowState[i] = new Pixel("\x1b[48;2;40;40;40m", "\x1b[38;2;255;255;255m", ' ');
				Console.Write(windowState[i].ToString());
            }
        }

        public void DrawWindow()
        {
            Console.SetCursorPosition(0, 0);
            List<string> stringState = [];
            for (int i = 0; i < windowState.Length; i++)
            {
                stringState.Add(windowState[i].ToString());
			}
            Console.Write(string.Join("", stringState));
		}

        public void DrawHelp()
        {
            DrawRectangle((0, Console.WindowHeight / 16 + 1), (Console.WindowWidth - 1, Console.WindowHeight - 1), 'X', false);
            WriteAtPos((3, Console.WindowHeight / 16 + 4), "Módok között váltás: ", "\x1b[38;2;255;255;255m");
			WriteAtPos((3, Console.WindowHeight / 16 + 6), "Az 1, 2 és 3-as gombokkal lehet váltani a 3 féle mód között: ", "\x1b[38;2;255;255;255m");
            WriteAtPos((7, Console.WindowHeight / 16 + 8), "Rajz mód: 1-es gombbal lehet kiválasztani, ebben a módban lehet a színek között is váltogatni a megfelelő betűkkel. A space lenyomásakor rajzol a kurzor helyén a kiválasztott színnel", "\x1b[38;2;255;255;255m");
            WriteAtPos((7, Console.WindowHeight / 16 + 11), "Alakzat mód: 2-es gombbal lehet kiválasztani, ebben a módban lehet alakzatok rajzolni. A space-el lehet kiválasztani a pontokat, és a kiválasztott színnel fogja megrajzolni. Az utolsó gomb lenyomásakor, ha a shiftet is nyomjuk,", "\x1b[38;2;255;255;255m");
            WriteAtPos((7, Console.WindowHeight / 16 + 13), "akkor kitölti az alakzatot, egyébként csak a körvonalát rajzolja meg.", "\x1b[38;2;255;255;255m");
            WriteAtPos((7, Console.WindowHeight / 16 + 16), "Segítség mód: 3-as gombbal lehet felhozni ezt az ablakot, 1 vagy 2-es gombbal lehet visszamenni a rajzfelületre. ", "\x1b[38;2;255;255;255m");
		}

        public void WriteAtPos((int x, int y) pos, string text, string foregroundColor)
        {
            Console.SetCursorPosition(pos.x, pos.y);
            for (int i = 0; i < text.Length; i++)
            {
                windowState[pos.y * Console.WindowWidth + pos.x + i].ForegroundColor = foregroundColor;
                windowState[pos.y * Console.WindowWidth + pos.x + i].Character = text[i];
                Console.Write(windowState[pos.y * Console.WindowWidth + pos.x + i].ToString());
            }
            Console.SetCursorPosition(pos.x, pos.y);
        }

        public void DrawAtPos((int x, int y) pos, char colorCode)
		{
			Console.SetCursorPosition(pos.x, pos.y);

			windowState[pos.y * Console.WindowWidth + pos.x].BackgroundColor = colors[colorCode];
			Console.Write(windowState[pos.y * Console.WindowWidth + pos.x].ToString());

            Console.SetCursorPosition(pos.x, pos.y);
		}

        public void DrawAtPos((int x, int y) pos, string trueColorString)
        {
            Console.SetCursorPosition(pos.x, pos.y);

            windowState[pos.y * Console.WindowWidth + pos.x].BackgroundColor = trueColorString;
            Console.Write(windowState[pos.y * Console.WindowWidth + pos.x].ToString());

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

        public void DrawLine((int x, int y) start, (int x, int y) end, string trueColorString)
        {
            if (start == end)
            {
                DrawAtPos(start, trueColorString);
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
                    DrawAtPos((Convert.ToInt32(start.x + xDirection * (xI * xStep)), Convert.ToInt32(start.y + yDirection * (yI * yStep))), trueColorString);
                    xI += xDirection;
                    yI += yDirection;
                }
                return;
            }
        }

        public void DrawRectangle((int x, int y) start, (int x, int y) end, char colorCode, bool fill)
        {
            List<(int x, int y)> ySorban = [start, end];
            ySorban = ySorban.OrderBy(a => a.y).ToList();
            List<(int x, int y)> xSorban = [start, end];
            xSorban = xSorban.OrderBy(a => a.x).ToList();

            if (fill)
            {
                for (int y = ySorban[0].y; y <= ySorban[1].y; y++)
                {
                    DrawLine((xSorban[0].x, y), (xSorban[1].x, y), colorCode);
                }
            }
            else
            {
                DrawLine(start, (end.x, start.y), colorCode);
                DrawLine((start.x, end.y), end, colorCode);
                DrawLine(start, (start.x, end.y), colorCode);
                DrawLine((end.x, start.y), end, colorCode);
            }
        }

        public void DrawRectangle((int x, int y) start, (int x, int y) end, string trueColorString, bool fill)
        {
            List<(int x, int y)> ySorban = [start, end];
            ySorban = ySorban.OrderBy(a => a.y).ToList();
            List<(int x, int y)> xSorban = [start, end];
            xSorban = xSorban.OrderBy(a => a.x).ToList();

            if (fill)
            {
                for (int y = ySorban[0].y; y <= ySorban[1].y; y++)
                {
                    DrawLine((xSorban[0].x, y), (xSorban[1].x, y), trueColorString);
                }
            }
            else
            {
                DrawLine(start, (end.x, start.y), trueColorString);
                DrawLine((start.x, end.y), end, trueColorString);
                DrawLine(start, (start.x, end.y), trueColorString);
                DrawLine((end.x, start.y), end, trueColorString);
            }
        }

        public void DrawTriangle((int x, int y) a, (int x, int y) b, (int x, int y) c, char colorCode, bool fill)
        {
            if (fill)
            {
                List<(int x, int y)> ySorban = [a, b, c];
                ySorban = ySorban.OrderBy(a => a.y).ToList();

                //oldalak normálvektorai
                //top-mid
                //top-bot
                //mid-bot
                (int x, int y) nv1 = (ySorban[0].y - ySorban[1].y, (ySorban[0].x - ySorban[1].x) * -1);
                (int x, int y) nv2 = (ySorban[0].y - ySorban[2].y, (ySorban[0].x - ySorban[2].x) * -1);
                (int x, int y) nv3 = (ySorban[1].y - ySorban[2].y, (ySorban[1].x - ySorban[2].x) * -1);

                for (int y = ySorban[0].y; y <= ySorban[2].y; y++)
                {
                    List<double> borderX = [];

                    //ameddig a top-mid oldal érvényes
                    if (y < ySorban[1].y)
                    {
                        if (nv1.x == 0)
                        {
                            borderX.Add(ySorban[0].x);
                        }
                        else
                        {
                            borderX.Add(ySorban[1].x - (nv1.y * y - nv1.y * ySorban[1].y) / nv1.x);
                        }
                    }
                    //mid-bot oldal
                    else
                    {
                        if (nv3.x == 0)
                        {
                            borderX.Add(ySorban[1].x);
                        }
                        else
                        {
                            borderX.Add(ySorban[2].x - (nv3.y * y - nv3.y * ySorban[2].y) / nv3.x);
                        }
                    }
                    if (nv2.x == 0)
                    {
                        borderX.Add(ySorban[2].x);
                    }
                    else
                    {
                        borderX.Add(ySorban[2].x - (nv2.y * y - nv2.y * ySorban[2].y) / nv2.x);
                    }
                    borderX = borderX.OrderBy(x => x).ToList();

                    for (int x = 0; x <= Console.WindowWidth; x++)
                    {
                        if (x >= Math.Ceiling(borderX[0]) && x <= Math.Floor(borderX[1]))
                        {
                            DrawAtPos((x, y), colorCode);
                        }
                    }
                }
            }
            else
            {
                DrawLine(a, b, colorCode);
                DrawLine(a, c, colorCode);
                DrawLine(b, c, colorCode);
            }
        }

        public void DrawTriangle((int x, int y) a, (int x, int y) b, (int x, int y) c, string trueColorString, bool fill)
        {
            if (fill)
            {
                List<(int x, int y)> ySorban = [a, b, c];
                ySorban = ySorban.OrderBy(a => a.y).ToList();

                //oldalak normálvektorai
                //top-mid
                //top-bot
                //mid-bot
                (int x, int y) nv1 = (ySorban[0].y - ySorban[1].y, (ySorban[0].x - ySorban[1].x) * -1);
                (int x, int y) nv2 = (ySorban[0].y - ySorban[2].y, (ySorban[0].x - ySorban[2].x) * -1);
                (int x, int y) nv3 = (ySorban[1].y - ySorban[2].y, (ySorban[1].x - ySorban[2].x) * -1);

                for (int y = ySorban[0].y; y <= ySorban[2].y; y++)
                {
                    List<double> borderX = [];

                    //ameddig a top-mid oldal érvényes
                    if (y < ySorban[1].y)
                    {
                        if (nv1.x == 0)
                        {
                            borderX.Add(ySorban[0].x);
                        }
                        else
                        {
                            borderX.Add(ySorban[1].x - (nv1.y * y - nv1.y * ySorban[1].y) / nv1.x);
                        }
                    }
                    //mid-bot oldal
                    else
                    {
                        if (nv3.x == 0)
                        {
                            borderX.Add(ySorban[1].x);
                        }
                        else
                        {
                            borderX.Add(ySorban[2].x - (nv3.y * y - nv3.y * ySorban[2].y) / nv3.x);
                        }
                    }
                    if (nv2.x == 0)
                    {
                        borderX.Add(ySorban[2].x);
                    }
                    else
                    {
                        borderX.Add(ySorban[2].x - (nv2.y * y - nv2.y * ySorban[2].y) / nv2.x);
                    }
                    borderX = borderX.OrderBy(x => x).ToList();

                    for (int x = 0; x <= Console.WindowWidth; x++)
                    {
                        if (x >= Math.Ceiling(borderX[0]) && x <= Math.Floor(borderX[1]))
                        {
                            DrawAtPos((x, y), trueColorString);
                        }
                    }
                }
            }
            else
            {
                DrawLine(a, b, trueColorString);
                DrawLine(a, c, trueColorString);
                DrawLine(b, c, trueColorString);
            }
        }

		public void DrawCircle((int x, int y) center, int radius, char colorCode, bool fill)
		{
			if (fill)
			{
                for (int y = center.y - radius; y < center.y + radius + 1; y++)
                {
                    for (int x = center.x - radius; x < center.x + radius + 1; x++)
                    {
                        if (Math.Pow(x - center.x, 2) + Math.Pow(y - center.y, 2) <= Math.Pow(radius, 2) + radius)
                        {
                            DrawAtPos((x, y), colorCode);
                        }
                    }
                }
            }
			else
			{
				for (int y = center.y - radius; y < center.y + radius + 1; y++)
				{
					for (int x = center.x - radius; x < center.x + radius + 1; x++)
					{
						if (Math.Abs(Math.Pow(x - center.x, 2) + Math.Pow(y - center.y, 2) - Math.Pow(radius, 2)) <= radius)
						{
							DrawAtPos((x, y), colorCode);
						}
                    }
                }
			}
		}

        public void DrawCircle((int x, int y) center, int radius, string trueColorString, bool fill)
        {
            if (fill)
            {
                for (int y = center.y - radius; y < center.y + radius + 1; y++)
                {
                    for (int x = center.x - radius; x < center.x + radius + 1; x++)
                    {
                        if (Math.Pow(x - center.x, 2) + Math.Pow(y - center.y, 2) <= Math.Pow(radius, 2) + radius)
                        {
                            DrawAtPos((x, y), trueColorString);
                        }
                    }
                }
            }
            else
            {
                for (int y = center.y - radius; y < center.y + radius + 1; y++)
                {
                    for (int x = center.x - radius; x < center.x + radius + 1; x++)
                    {
                        if (Math.Abs(Math.Pow(x - center.x, 2) + Math.Pow(y - center.y, 2) - Math.Pow(radius, 2)) <= radius)
                        {
                            DrawAtPos((x, y), trueColorString);
                        }
                    }
                }
            }
        }
    }
}
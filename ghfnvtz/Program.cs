using System.Diagnostics;

namespace ghfnvtz
{
    internal class Program
    {
        static Window helpWindow = new Window();

        static Window window = new Window();
        static string currentMode = "draw";
        static string selectedColor = "\x1b[48;2;255;255;255m";
        static string selectedShape = "rectangle";
        static List<(int x, int y)> selectedShapePoints = new List<(int, int)>();

        static void Main(string[] args)
        {
			window.Setup();

            RajzoloSetup();

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);

            while (true)
            {
                var key = Console.ReadKey(true);
                
                switch (key.Key)
                {
                    #region Mód váltás
                    case ConsoleKey.D1:
                        UpdateMode("draw");
                        break;
                    case ConsoleKey.D2:
                        UpdateMode("shape");
                        break;
                    case ConsoleKey.D3:
                        UpdateMode("help");
                        break;
                    #endregion

                    #region Cursor mozgás
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop - 1 >= /*Console.WindowHeight / 16 egyelőre kell hogy oda is menjen*/ 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop + 1 != Console.WindowHeight)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft - 1 >= 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.CursorLeft + 1 != Console.WindowWidth)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        }
                        break;
                    #endregion

                    #region Szín kiválasztás
                    case ConsoleKey.F:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['F']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['f']);
                            }
                        }
                        break;
                    case ConsoleKey.K:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['K']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['k']);
                            }
                        }
                        break;
                    case ConsoleKey.Z:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['Z']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['z']);
                            }
                        }
                        break;
                    case ConsoleKey.C:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['C']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['c']);
                            }
                        }
                        break;
                    case ConsoleKey.P:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['P']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['p']);
                            }
                        }
                        break;
                    case ConsoleKey.M:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['M']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['m']);
                            }
                        }
                        break;
                    case ConsoleKey.S:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['S']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['s']);
                            }
                        }
                        break;
                    case ConsoleKey.X:
                        if (currentMode == "draw")
                        {
                            if (key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                            {
                                UpdateSelectedColor(window.colors['X']);
                            }
                            else
                            {
                                UpdateSelectedColor(window.colors['x']);
                            }
                        }
                        break;
                    #endregion

                    #region alakzat váltás
                    case ConsoleKey.D6:
                        UpdateShape("line");
                        break;
                    case ConsoleKey.D7:
                        UpdateShape("rectangle");
                        break;
                    case ConsoleKey.D8:
                        UpdateShape("triangle");
                        break;
                    //case ConsoleKey.D9:
                    //    UpdateShape("circle");
                    //    break;
                    #endregion

                    #region alakzat rajzolás
                    case ConsoleKey.Spacebar:
                        if (currentMode == "draw")
                        {
                            window.DrawAtPos((Console.CursorLeft, Console.CursorTop), selectedColor);
                        }
                        else if (currentMode == "shape")
                        {
                            //if (selectedShape == "circle")
                            //{
                            //    selectedShapePoints.Add((Console.CursorLeft, Console.CursorTop));

                            //    Console.Write("sugár: ");
                            //    int r = int.Parse(Console.ReadLine());
                            //    window.DrawCircle(selectedShapePoints[0], r, selectedColor, key.Modifiers.HasFlag(ConsoleModifiers.Shift));
                            //    Console.SetCursorPosition(selectedShapePoints[0].x, selectedShapePoints[0].y);
                            //    window.WriteAtPos(selectedShapePoints[0], "       ", selectedColor);
                            //}

                            if (selectedShape == "line")
                            {
                                selectedShapePoints.Add((Console.CursorLeft, Console.CursorTop));
                                window.DrawAtPos((Console.CursorLeft, Console.CursorTop), selectedColor);
                                if (selectedShapePoints.Count == 2)
                                {
                                    window.DrawLine(selectedShapePoints[0], selectedShapePoints[1], selectedColor);
                                    selectedShapePoints.Clear();
                                }
                            }
                            else if (selectedShape == "rectangle")
                            {
                                selectedShapePoints.Add((Console.CursorLeft, Console.CursorTop));
                                window.DrawAtPos((Console.CursorLeft, Console.CursorTop), selectedColor);
                                if (selectedShapePoints.Count == 2)
                                {
                                    window.DrawRectangle(selectedShapePoints[0], selectedShapePoints[1], selectedColor, key.Modifiers.HasFlag(ConsoleModifiers.Shift));
                                    selectedShapePoints.Clear();
                                }
                            }
                            else if (selectedShape == "triangle")
                            {
                                selectedShapePoints.Add((Console.CursorLeft, Console.CursorTop));
                                window.DrawAtPos((Console.CursorLeft, Console.CursorTop), selectedColor);
                                if (selectedShapePoints.Count == 3)
                                {
                                    window.DrawTriangle(selectedShapePoints[0], selectedShapePoints[1], selectedShapePoints[2], selectedColor, key.Modifiers.HasFlag(ConsoleModifiers.Shift));
                                    selectedShapePoints.Clear();
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (currentMode == "shape")
                        {
                            selectedShapePoints.Clear();
                        }
                        break;
                    #endregion

                    //átmeneti
                    case ConsoleKey.Enter:
                        Trace.WriteLine($"Cursor pos: {Console.GetCursorPosition()}");
                        break;

                    default:
                        break;
                }
            }
        }

        static void RajzoloSetup()
        {
            //UI
            //mode jelzp
            window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;30;30;30m", true);
            window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;35;52;83m", false);
            window.WriteAtPos((2, Console.WindowHeight / 32), "Mód: 1. rajz / 2. alakzat / 3. segítség", "\x1b[38;2;255;255;255m");
            UpdateMode(currentMode);

            //színek
            //szín paletta háttér
            window.DrawRectangle((Console.WindowWidth / 2 - 8, 1), (Console.WindowWidth / 2 + 8, 7), "\x1b[48;2;30;30;30m", true);
            //kiválasztott szín keret
            UpdateSelectedColor(selectedColor);

            for (int x = 0; x < 8; x++)
            {
                window.DrawAtPos(((Console.WindowWidth / 2 - 7) + x * 2, 2), window.colors.ElementAt(x).Value);
                window.WriteAtPos(((Console.WindowWidth / 2 - 7) + x * 2, 3), window.colors.ElementAt(x).Key.ToString(), "\x1b[38;2;255;255;255m");

                window.DrawAtPos(((Console.WindowWidth / 2 - 7) + x * 2, 5), window.colors.ElementAt(x + 8).Value);
                window.WriteAtPos(((Console.WindowWidth / 2 - 7) + x * 2, 6), window.colors.ElementAt(x + 8).Key.ToString(), "\x1b[38;2;255;255;255m");
            }

            //alakzatok
            string kivalasztottText = "Kiválaszott pontok: ";
            string alakzatText = "Alakzatok: 6. vonal / 7. téglalap / 8.háromszög / 9. kör";
			window.WriteAtPos((Console.WindowWidth - 2 - alakzatText.Length, 4), alakzatText, "\x1b[38;2;255;255;255m");
            UpdateShape(selectedShape);
		}

        static void UpdateShape(string shape)
        {
			(int, int) pos = Console.GetCursorPosition();
            selectedShape = shape;

            switch (shape)
            {
                case "line":
                    window.WriteAtPos((193, 4), "6. vonal", "\x1b[38;2;220;0;0m");
                    window.WriteAtPos((204, 4), "7. téglalap", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((218, 4), "8. háromszög", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((232, 4), "9. kör", "\x1b[38;2;255;255;255m");
                    break;
                case "rectangle":
                    window.WriteAtPos((193, 4), "6. vonal", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((204, 4), "7. téglalap", "\x1b[38;2;220;0;0m");
                    window.WriteAtPos((218, 4), "8. háromszög", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((232, 4), "9. kör", "\x1b[38;2;255;255;255m");
                    break;
                case "triangle":
                    window.WriteAtPos((193, 4), "6. vonal", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((204, 4), "7. téglalap", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((218, 4), "8. háromszög", "\x1b[38;2;220;0;0m");
                    window.WriteAtPos((232, 4), "9. kör", "\x1b[38;2;255;255;255m");
                    break;
                case "circle":
                    window.WriteAtPos((193, 4), "6. vonal", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((204, 4), "7. téglalap", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((218, 4), "8. háromszög", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((232, 4), "9. kör", "\x1b[38;2;220;0;0m");
                    break;
                default:
                    break;
			}

			Console.SetCursorPosition(pos.Item1, pos.Item2);
		}

        static void UpdateMode(string mode)
        {
            (int, int) pos = Console.GetCursorPosition();
            currentMode = mode;

            switch (mode)
            {
                case "draw":
                    window.WriteAtPos((7, Console.WindowHeight / 32), "1. rajz", "\x1b[38;2;220;0;0m");
                    window.WriteAtPos((17, Console.WindowHeight / 32), "2. alakzat", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((30, Console.WindowHeight / 32), "3. segítség", "\x1b[38;2;255;255;255m");
                    break;
                case "shape":
                    window.WriteAtPos((7, Console.WindowHeight / 32), "1. rajz", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((17, Console.WindowHeight / 32), "2. alakzat", "\x1b[38;2;220;0;0m");
                    window.WriteAtPos((30, Console.WindowHeight / 32), "3. segítség", "\x1b[38;2;255;255;255m");
                    break;
                case "help":
                    window.WriteAtPos((7, Console.WindowHeight / 32), "1. rajz", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((17, Console.WindowHeight / 32), "2. alakzat", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((30, Console.WindowHeight / 32), "3. segítség", "\x1b[38;2;220;0;0m");
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(pos.Item1, pos.Item2);
        }

        static void UpdateSelectedColor(string color)
        {
            (int, int) pos = Console.GetCursorPosition();
            window.DrawRectangle((Console.WindowWidth / 2 - 13, 3), (Console.WindowWidth / 2 - 11, 5), color, true);
            selectedColor = color;
            Console.SetCursorPosition(pos.Item1, pos.Item2);
        }
    }
}

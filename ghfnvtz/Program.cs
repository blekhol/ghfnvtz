namespace ghfnvtz
{
    internal class Program
    {
        static Window window = new Window();
        static string currentMode = "draw";

        static void Main(string[] args)
        {
			window.Setup();

            int select = 0; //mennyiszer lett már selectelve
			(int, int) selectStartPos = (0, 0);
			(int, int) selectEndPos = (0, 0);

            //UI
            //mode jelzp
            window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;11;11;11m", true);
            window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;35;52;83m", false);
            window.WriteAtPos((2, Console.WindowHeight / 32), "Mód: 1. rajz / 2. alakzat / 3. segítség", "\x1b[38;2;255;255;255m");
            UpdateMode(currentMode);
            
            //színek

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);

            window.DrawRectangle((100, 70), (20, 25), 'K', true);

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
                        if (Console.CursorTop - 1 > Console.WindowHeight / 16)
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


                    default:
                        break;
                }
            }
        }

        static void UpdateMode(string mode)
        {
            (int, int) pos = Console.GetCursorPosition();
            switch (mode)
            {
                case "draw":
                    window.WriteAtPos((7, Console.WindowHeight / 32), "1. rajz", "\x1b[38;2;220;0;0m");
                    window.WriteAtPos((17, Console.WindowHeight / 32), "2. alakzat", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((30, Console.WindowHeight / 32), "3. segítség", "\x1b[38;2;255;255;255m");
                    currentMode = mode;
                    break;
                case "shape":
                    window.WriteAtPos((7, Console.WindowHeight / 32), "1. rajz", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((17, Console.WindowHeight / 32), "2. alakzat", "\x1b[38;2;220;0;0m");
                    window.WriteAtPos((30, Console.WindowHeight / 32), "3. segítség", "\x1b[38;2;255;255;255m");
                    currentMode = mode;
                    break;
                case "help":
                    window.WriteAtPos((7, Console.WindowHeight / 32), "1. rajz", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((17, Console.WindowHeight / 32), "2. alakzat", "\x1b[38;2;255;255;255m");
                    window.WriteAtPos((30, Console.WindowHeight / 32), "3. segítség", "\x1b[38;2;220;0;0m");
                    currentMode = mode;
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(pos.Item1, pos.Item2);
        }
    }
}

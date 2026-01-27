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
            window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;11;11;11m ", true);
            window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;35;52;83m \x1b[0m", false);
            window.WriteAtPos((2, Console.WindowHeight / 32), "Mód: 1. rajz / 2. alakzat / 3. segítség", "\x1b[38;2;255;255;255m");
            UpdateMode(currentMode);
            


            Console.ReadKey();
        }

        static void UpdateMode(string mode)
        {
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
        }
    }
}

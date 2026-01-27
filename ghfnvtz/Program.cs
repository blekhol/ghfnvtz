namespace ghfnvtz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window();
			window.Setup();

            string mode = "select";
			int select = 0; //mennyiszer lett már selectelve
			(int, int) selectStartPos = (0, 0);
			(int, int) selectEndPos = (0, 0);

			Console.SetCursorPosition(100, 70);
            window.DrawCircle((100, 70), 10, 'p', true);

            ////UI
            //window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;11;11;11m ", true);
            //window.DrawRectangle((0, 0), (Console.WindowWidth - 1, Console.WindowHeight / 16), "\x1b[48;2;35;52;83m \x1b[0m", false);
            //Console.SetCursorPosition(2, Console.WindowHeight / 32);
            //window.Write("Mode: select / draw / shape");

            Console.ReadKey();
        }

        static void UpdateMode(string mode)
        {
            
        }
    }
}

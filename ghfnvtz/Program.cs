namespace ghfnvtz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window();
			window.Setup();

            string mode = "";
			int select = 0; //mennyiszer lett már selectelve
			(int, int) selectStartPos = (0, 0);
			(int, int) selectEndPos = (0, 0);

            //window.DrawRectangle((0, 0), (Console.WindowWidth - 1, 6), "\x1b[48;2;48;48;48m ");
            window.DrawRectangle((0, 0), (10, 10), 'S', true);

            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        try
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                        catch (Exception)
                        {
							break;
						}
                        break;
                    case ConsoleKey.UpArrow:
						try
						{
							Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
						}
						catch (Exception)
						{
							break;
						}
						break;
                    case ConsoleKey.RightArrow:
						try
						{
							Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
						}
						catch (Exception)
						{
							break;
						}
						break;
                    case ConsoleKey.DownArrow:
						try
						{
							Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
						}
						catch (Exception)
						{
							break;
						}
						break;
                    case ConsoleKey.Spacebar:
						if (mode == "color")
						{
							mode = "";
						}
						else
						{
							mode = "color";
						}
						break;
					case ConsoleKey.P:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'P');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'p');
							}
						}
						break;
					case ConsoleKey.F:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'F');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'f');
							}
						}
						break;
					case ConsoleKey.K:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'K');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'k');
							}
						}
						break;
					case ConsoleKey.Z:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'Z');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'z');
							}
						}
						break;
					case ConsoleKey.C:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'C');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'c');
							}
						}
						break;
					case ConsoleKey.M:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'M');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'m');
							}
						}
						break;
					case ConsoleKey.S:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'S');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'s');
							}
						}
						break;
					case ConsoleKey.X:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'X');
							}
							else
							{
								window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'x');
							}
						}
						break;
					case ConsoleKey.Enter:
						if (mode == "select" && select == 0)
						{
							selectStartPos = (Console.CursorLeft, Console.CursorTop);
							window.DrawAtPos((Console.CursorLeft, Console.CursorTop),'c');
							select++;
						}
						else if (mode == "select" && select == 1)
						{
							selectEndPos = (Console.CursorLeft, Console.CursorTop);
							window.DrawAtPos((Console.CursorLeft, Console.CursorTop), 'c');

							//window.DrawRectangle(selectStartPos, selectEndPos, 'P');

							selectStartPos = (0, 0);
							selectEndPos = (0, 0);
							select = 0;
							mode = "";
						}
						else
						{
							mode = "select";
						}
						break;
					case ConsoleKey.Escape:
                        window.DrawRectangle((Console.CursorLeft, Console.CursorTop), (Console.CursorLeft + 10, Console.CursorTop + 10), 'S', true);
						break;
                    default:
                        break;
                }
            }
        }
    }
}

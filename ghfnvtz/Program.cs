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

			Console.SetCursorPosition(100, 70);

			window.DrawTriangle((10, 10), (20, 30), (30, 10), 'M', true);

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

							window.DrawRectangle(selectStartPos, selectEndPos, 'P', (key.Modifiers == ConsoleModifiers.Shift));

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
                    default:
                        break;
                }
            }
        }
    }
}

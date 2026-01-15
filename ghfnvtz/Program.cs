namespace ghfnvtz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window();
            window.Setup();

			string mode = "";

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
								window.DrawAtPos('P');
							}
							else
							{
								window.DrawAtPos('p');
							}
						}
						break;
					case ConsoleKey.F:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos('F');
							}
							else
							{
								window.DrawAtPos('f');
							}
						}
						break;
					case ConsoleKey.K:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos('K');
							}
							else
							{
								window.DrawAtPos('k');
							}
						}
						break;
					case ConsoleKey.Z:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos('Z');
							}
							else
							{
								window.DrawAtPos('z');
							}
						}
						break;
					case ConsoleKey.C:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos('C');
							}
							else
							{
								window.DrawAtPos('c');
							}
						}
						break;
					case ConsoleKey.M:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos('M');
							}
							else
							{
								window.DrawAtPos('m');
							}
						}
						break;
					case ConsoleKey.S:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos('S');
							}
							else
							{
								window.DrawAtPos('s');
							}
						}
						break;
					case ConsoleKey.X:
						if (mode == "color")
						{
							if (key.Modifiers == ConsoleModifiers.Shift)
							{
								window.DrawAtPos('X');
							}
							else
							{
								window.DrawAtPos('x');
							}
						}
						break;
					default:
                        break;
                }
            }
        }
    }
}

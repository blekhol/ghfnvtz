namespace ghfnvtz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window();
            window.Setup();

            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey();

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
                    
                    default:
                        break;
                }
            }
        }
    }
}

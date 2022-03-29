namespace ConsoleLibrary
{
    public class ColoredConsole
    {
        public static string Prompt(string question)
        {
            Console.Write(question + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string answer = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            return answer;
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;

            return;
        }

        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;

            return;
        }
    }
}

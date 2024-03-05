namespace assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }
            string filename = args[0];
            Program myProgram = new Program();
            myProgram.Start(filename);
        }
        void Start(string filename)
        {
            Console.Write("Enter a word (to search for): ");
            string word = Console.ReadLine();
            int lines = SearchWordInFile(filename, word);
            Console.WriteLine();
            Console.WriteLine($"Number of lines containing the word: {lines}");
        }
        bool WordInLine(string line, string word)
        {
            if (line.Contains(word, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        int SearchWordInFile(string filename, string word)
        {
            string line;
            int lines = 0;
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (WordInLine(line, word))
                {
                    DisplayWordInLine(line, word);
                    lines++;
                }
            }
            reader.Close();
            return lines;
        }
        void DisplayWordInLine(string line, string word)
        {
            Console.WriteLine();
            int offset = line.IndexOf(word, StringComparison.OrdinalIgnoreCase);
            Console.Write(line.Substring(0, offset));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[{line.Substring(offset, word.Length)}]");
            Console.ResetColor();
            Console.WriteLine(line.Substring(offset + word.Length, line.Length - offset - word.Length));
        }
    }
}

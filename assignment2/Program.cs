namespace assignment2
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
            HangmanGame hangman = new HangmanGame();
            List<string> words = new List<string>();
            words = ListOfWords(filename);
            hangman.Init(SelectWord(words));
            DisplayWord(hangman.guessedWord);
            bool victory = PlayHangman(hangman);
            if (victory)
            {
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine($"Too bad, you did not guess the word ({hangman.secretWord})");
            }
        }
        List<string> ListOfWords(string filename)
        {
            List<string> secretWords = new List<string>();
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                secretWords.Add(reader.ReadLine());
            }
            reader.Close();
            return secretWords;
        }
        string SelectWord(List<string> words)
        {
            Random random = new Random();
            string word;
            do
            {
                word = words[random.Next(0, words.Count)];
            }
            while (word.Length < 3);
            return word;
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }
        char ReadLetter(List<char> blacklistLetters)
        {
            char letter;
            do
            {
                Console.Write("Enter a letter: ");
                letter = Convert.ToChar(Console.ReadLine());
            }
            while (blacklistLetters.Contains(letter));
            return letter;
        }
        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in letters)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }
        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            int attempts = 8;

            while (attempts != 0)
            {
                char letter = ReadLetter(enteredLetters);
                enteredLetters.Add(letter);
                DisplayLetters(enteredLetters);
                if (hangman.ContainsLetter(letter))
                {
                    hangman.ProcessLetter(letter);
                }
                else
                    attempts--;
                Console.WriteLine($"Attempts left: {attempts}");
                Console.WriteLine();
                DisplayWord(hangman.guessedWord);
                if (hangman.IsGuessed())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

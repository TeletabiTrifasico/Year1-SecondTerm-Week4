using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2
{
    internal class HangmanGame
    {
        public string secretWord;
        public string guessedWord;
        public void Init(string secretWord)
        {
            this.secretWord = secretWord;
            foreach (char c in secretWord)
            {
                guessedWord = guessedWord + ".";
            }
        }
        public bool ContainsLetter(char letter)
        {
            foreach (char c in secretWord)
            {
                if (c == letter)
                {
                    return true;
                }
            }
            return false;
        }
        public void ProcessLetter(char letter)
        {
            string dummyGuessedWord = null;
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (letter == secretWord[i])
                {
                    dummyGuessedWord += secretWord[i];
                }
                else
                {
                    dummyGuessedWord += guessedWord[i];
                }
            }
            guessedWord = dummyGuessedWord;
        }
        public bool IsGuessed()
        {
            if (secretWord == guessedWord)
            {
                return true;
            }
            return false;
        }
    }
}

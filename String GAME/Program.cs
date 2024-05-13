using System;

class Program
{
    static string[] words = { "apple", "banana", "orange", "grape", "pineapple" };
    static Random random = new Random();
    static string wordToGuess;
    static char[] guessedLetters;
    static int attemptsLeft = 6;
    static bool gameOver = false;

    static void Main(string[] args)
    {
        wordToGuess = words[random.Next(words.Length)];
        guessedLetters = new char[wordToGuess.Length];

        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine("Try to guess the word.");

        while (!gameOver)
        {
            DisplayWord();
            DisplayHangman();
            Console.WriteLine($"Attempts left: {attemptsLeft}");
            Console.Write("Enter a letter or guess the whole word: ");
            string input = Console.ReadLine().ToLower();

            if (input.Length == 1) // Single letter guess
            {
                char letter = input[0];
                if (char.IsLetter(letter))
                {
                    if (GuessLetter(letter))
                    {
                        Console.WriteLine("Correct guess!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect guess.");
                        attemptsLeft--;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a letter.");
                }
            }
            else if (input.Length == wordToGuess.Length) // Whole word guess
            {
                if (input == wordToGuess)
                {
                    Console.WriteLine("Congratulations! You've guessed the word correctly!");
                    gameOver = true;
                }
                else
                {
                    Console.WriteLine("Incorrect guess.");
                    attemptsLeft--;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter or guess the whole word.");
            }

            if (attemptsLeft == 0)
            {
                Console.WriteLine($"You're out of attempts! The word was: {wordToGuess}");
                gameOver = true;
            }

            if (!guessedLetters.Contains('_')) // All letters guessed
            {
                Console.WriteLine("Congratulations! You've guessed the word correctly!");
                gameOver = true;
            }
        }
    }

    static void DisplayWord()
    {
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (guessedLetters[i] == '\0')
            {
                Console.Write("_ ");
            }
            else
            {
                Console.Write(guessedLetters[i] + " ");
            }
        }
        Console.WriteLine();
    }

    static bool GuessLetter(char letter)
    {
        bool found = false;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == letter)
            {
                guessedLetters[i] = letter;
                found = true;
            }
        }
        return found;
    }

    static void DisplayHangman()
    {
        switch (attemptsLeft)
        {
            case 6:
                Console.WriteLine(@"
  +---+
  |   |
      |
      |
      |
      |
=========");
                break;
            case 5:
                Console.WriteLine(@"
  +---+
  |   |
  O   |
      |
      |
      |
=========");
                break;
            case 4:
                Console.WriteLine(@"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========");
                break;
            case 3:
                Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========");
                break;
            case 2:
                Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========");
                break;
            case 1:
                Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========");
                break;
            case 0:
                Console.WriteLine(@"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========");
                break;
        }
    }
}

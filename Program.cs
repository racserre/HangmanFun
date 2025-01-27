using System.ComponentModel.Design;
using HangmanFun;

// Declare all variables and objects at the top
HangmanTools ht = new HangmanTools();

string solution = "";
string guess = "";
string lettersGuessed = "";
int inCorrectGuesses = 0;


bool gameOver = false;

// Welcome the user to the game
Console.WriteLine("Welcome to our Hangman Game!");


// Get the random word for the user to guess
Console.Write("Generating a random word");
Thread.Sleep(300);
Console.Write(".");
Thread.Sleep(300);
Console.Write(".");
Thread.Sleep(300);
Console.Write(".");

solution = ht.GetRandomWord();

Console.WriteLine();

Console.WriteLine("Alright, I have your word to guess!");

do
{
    // Get the user's guess
    Console.WriteLine("Please enter a letter: ");

    // Validate the guess
    do
    {
        guess = Console.ReadLine();


    } while (!ht.ValidGuess(guess, lettersGuessed));

    // Update the list of letters guessed
    lettersGuessed += guess;

    // Check to see if the letter is in the word
    if (solution.Contains(guess))
    {
        Console.WriteLine($"Yes, the letter {guess} is in the word!");


        if (ht.UpdateWord(lettersGuessed, solution) == solution)
        {
            Console.WriteLine("You won!");
            gameOver = true;
        }

        Console.WriteLine("Word: " + ht.UpdateWord(lettersGuessed, solution));
    }
    else // Guess was incorrect
    {
        Console.WriteLine($"Sorry, the word does not have the letter {guess}.");

        inCorrectGuesses++;

        if (inCorrectGuesses < 6)
        {
            Console.WriteLine($"You have {6 - inCorrectGuesses} guesses left");
        }
        if (inCorrectGuesses >= 6)
        {
            Console.WriteLine("Sorry, you lost!");
            Console.WriteLine($"The word was: {solution}");
            gameOver = true;
        }
        
    }


} while (!gameOver);

Console.WriteLine("Thanks for playing! Please come again!");
Console.WriteLine();
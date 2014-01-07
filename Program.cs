using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessingGameExample
{
    class Program
    {
        static void Main(string[] args)
        {

            // Declare and initialize variables
            const int MAXIMUM = 20;
            Random rnd = new Random();
            String sUserName = String.Empty;
            String sUserResp = String.Empty;
            int iMyNum = 0; // the computers randomly chosen number
            int iGuess = 0; // the user's guess each try
            int iCount = 0; // the number of guesses so far
            Boolean bRepeat = true;

            // Greet the user and ask his/her name.
            Console.WriteLine("Welcome to the Guessing Game!");
            Console.Write("\nWhat is your name, please? ");
            sUserName = Console.ReadLine();

            // Explain the game to the user, using his name.
            Console.Write("\nWell, " + sUserName + ", here's how the game is played:\n\nI will randomly choose a number");
            Console.Write(" between the values of 1 and {0:###}, inclusive.\n\nThen, you will try to guess my number.\n\nI will keep", MAXIMUM);
            Console.WriteLine(" track of how many tries you need in order to guess my number.");

            // Prepare to start looping through separate games.
            Pause("Press the enter key when you are ready to begin your first game.");

            while (bRepeat)
            {
                // Generate a random number under the MAXIMUM
                iMyNum = rnd.Next(1, MAXIMUM);
                iCount = 0;

                Console.WriteLine("\nI have chosen a number between 1 and {0:##}.", MAXIMUM);

                // The user starts guessing
                do
                {
                    Console.Write("\nOk, " + sUserName + ", enter a guess: ");
                    sUserResp = Console.ReadLine();
                    try
                    {
                        iGuess = Convert.ToInt32(sUserResp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nI'm sorry; an error has occurred: " + ex.Message);
                        Console.WriteLine("\nThis program must exit. Please rerun the program to try again.");
                        Pause("Press the enter key to close this window.");
                        return;
                    }

                    iCount++; // iCount = iCount + 1;

                    // At this point, the user entered a number.
                    if (iMyNum > iGuess)
                    {
                        Console.WriteLine("\nI'm sorry, " + sUserName + ", your guess is too low. Try a higher number.");
                    }
                    else if (iMyNum < iGuess)
                    {
                        Console.WriteLine("\nI'm sorry, " + sUserName + ", your guess is too high. Try a lower number.");
                    }
                    else
                    {
                        Pause("\nCongratulations, " + sUserName + "!! You guessed the number in {0:##} tries!", iCount);
                    }
                } while (iMyNum != iGuess);

                // Play again?
                Console.Write("\nWould you like to play again (Y or N), " + sUserName + "? ");
                sUserResp = Console.ReadLine().ToUpper();

                while ((sUserResp != "Y") && (sUserResp != "N"))
                {
                    Console.Write("I'm sorry, " + sUserName + ", but I didn't understand your response.");
                    Console.Write("\nWould you like to play again (Y or N)? ");
                    sUserResp = Console.ReadLine().ToUpper();
                }

                // Set the Boolean for repeat or no-repeat
                bRepeat = (sUserResp == "Y");
            }

            Pause("Ok, " + sUserName + ", thanks for playing! Hope you enjoyed it!\nPress the enter key to exit this window.");
        }

        static void Pause(String s)
        {
            Console.WriteLine(s);
            Console.ReadLine();
        }

        static void Pause(String s, int i)
        {
            Console.WriteLine(s, i);
            Console.ReadLine();
        }
    }
}

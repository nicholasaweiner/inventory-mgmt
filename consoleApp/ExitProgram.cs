using System;
using System.Threading.Tasks;

namespace consoleApp
{
    class ExitProgram
    {
        public void Run()
        {
            Console.Write("Would you like to return to Main Menu? (Enter Y / N)");

            // User Return to Main Menu Input
            var userReturnInput = Console.ReadLine().ToLower();

            if ((userReturnInput == "y") || (userReturnInput == "yes"))
            {
                // *** Use Timer Here for Console Clear

                Console.Clear();
                var mainMenuReturn = new MainMenuReturn();
                mainMenuReturn.MainMenu();
            }
            else
            {
                Console.Write("Would you like to quit the application? (Enter Y / N)");

                // User Quit Application Input
                var userQuitInput = Console.ReadLine().ToLower();

                if ((userQuitInput == "y") || (userQuitInput == "yes"))
                {
                    Environment.Exit(0);

                }
                else
                {
                    // *** Use Timer Here for Console Clear

                    Console.Clear();
                    Console.WriteLine("Returning to Main Menu...");
                    var mainMenuReturn = new MainMenuReturn();
                    mainMenuReturn.MainMenu();
                }
                
            }
        }
    }
}


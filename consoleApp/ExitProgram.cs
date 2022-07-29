using System;

namespace consoleApp
{
    class ExitProgram
    {
        public void Run()
        {
            Console.Write("Would you like to return to Main Menu? (Enter Y / N) ");

            // User Return to Main Menu Input
            var userReturnInput = Console.ReadLine().ToLower();

            if ((userReturnInput == "y") || (userReturnInput == "yes"))
            {

                System.Threading.Thread.Sleep(2000);
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
                    Console.WriteLine("Returning to Main Menu...");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();

                    var mainMenuReturn = new MainMenuReturn();
                    mainMenuReturn.MainMenu();
                }
                
            }
        }
    }
}


using System;
using consoleApp.AppFrame;

namespace consoleApp
{
	class MainMenuReturn
	{
		public void MainMenu()
		{

            var frameHeader = new FrameHeader();

            // Default Application Frame - Header
            frameHeader.Run();

            Console.WriteLine(@"|   Main Menu:                                                            |
|                                                                         │
│    1 - Add an item to inventory                                         │
│    2 - Edit saved item details                                          │
│    3 - Remove an item from inventory                                    │
│    4 - Display all current inventory items                              │
│                                                                         │
│    5 - Exit                                                             │
│                                                                         │
└─────────────────────────────────────────────────────────────────────────┘ ");

            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    var add = new AddItem();
                    add.Run();
                    break;
                case "2":
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    var edit = new EditItem();
                    edit.Run();
                    break;
                case "3":
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    var remove = new RemoveItem();
                    remove.Run();
                    break;
                case "4":
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    var browse = new BrowseItems();
                    browse.Run();
                    break;
                case "5":
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    var exit = new ExitProgram();
                    exit.Run();
                    break;
                default:
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    var invalidUserInput = new ExitProgram();
                    invalidUserInput.Run();
                    break;
            }
        }
	}
}


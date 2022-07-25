using System;
namespace consoleApp
{
	class MainMenuReturn
	{
		public void MainMenu()
		{

            Console.WriteLine(@"
┌─────────────────────────────────────────────────────────────────────────┐
│                                                                         │
│   Inventory Management Application                                      │
│                                                                         │
│   Console App built by Nick Weiner using C#                             │
|                                                                         |
|   Main Menu:                                                            |
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
                    var add = new AddItem();
                    add.Run();
                    break;
                case "2":
                    var edit = new EditItem();
                    edit.Run();
                    break;
                case "3":
                    var remove = new RemoveItem();
                    remove.Run();
                    break;
                case "4":
                    var browse = new BrowseItems();
                    browse.Run();
                    break;
                case "5":
                    var exit = new ExitProgram();
                    exit.Run();
                    break;
                default:
                    var invalidUserInput = new ExitProgram();
                    invalidUserInput.Run();
                    break;
            }
        }
	}
}


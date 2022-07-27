using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using consoleApp.AppFrame;
using consoleApp.Commands;
using System.Reflection;

namespace consoleApp
{
    class AddItem
    {
        public void Run()
        {
            var frameHeader = new FrameHeader();
            var frameBodySpace = new FrameBodySpace();
            var frameFooter = new FrameFooter();
            var applicationCommands = new ApplicationCommands();
            int leftSpaces = 4;
            string leftPadding = new string(' ', leftSpaces);

            // Deserialize JSON file
            var json = File.ReadAllText(path: "itemType.json");
            var itemTypes = JsonConvert.DeserializeObject<List<ItemType>>(json);


            // Default Application Frame - Header
            frameHeader.Run();

            // Application Frame - Add Item Body
            applicationCommands.AddItemCommands();

            // Item Types
            applicationCommands.AddItemType();

            
            // Frame Body Space
            frameBodySpace.Run();

            // Frame Return to Main Menu 
            // Console.WriteLine($"│{leftPadding}{ Convert.ToInt32(items.Count) + 1} - Return to Main Menu                                              |");


            // Default Application Frame Footer
            frameFooter.Run();

            Console.Write("\r\nSelect an option: ");
            var input = Console.ReadLine();

            bool containsId = itemTypes.Any(p => p.id.ToString() == input);
            bool containsItemType = itemTypes.Any(p => p.itemType == input);

            if (containsId || containsItemType)
            {
                Console.WriteLine("Success");
            }
            else
            {
                var invalidUserInput = new ExitProgram();
                invalidUserInput.Run();
            }
        }

        public class ItemType
        {
            public int id { get; set; }
            public string itemType { get; set; }
        }

    }


}



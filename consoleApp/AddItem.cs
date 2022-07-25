using System;
using System.Linq;
using System.Collections.Generic;
using consoleApp.AppFrame;
using consoleApp.Commands;

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


            // Default Application Frame - Header
            frameHeader.Run();

            // Application Frame - Add Item Body
            applicationCommands.AddItemCommands();

            // Item Data

            var items = new List<Item>()
            {
                new Item(){ Id = 1, ItemType="Cable" },
                new Item(){ Id = 2, ItemType="Adapter" },
                new Item(){ Id = 3, ItemType="Misc. Peripheral" },
                new Item(){ Id = 4, ItemType="Device" }
            };

            // Data Display

            foreach (var el in items)
            {
                var charFreq = el.ItemType.Count();
                int multipler = 65;
                int rightSpaces = multipler - charFreq;
                string rightPadding = new string(' ', rightSpaces);


                Console.WriteLine($"│{leftPadding}{el.Id} - {el.ItemType}{rightPadding}|");
            }

            // Frame Body Space
            frameBodySpace.Run();

            // Frame Return to Main Menu 
            Console.WriteLine($"│{leftPadding}{ Convert.ToInt32(items.Count) + 1} - Return to Main Menu                                              |");


            // Default Application Frame Footer
            frameFooter.Run();

            Console.Write("\r\nSelect an option: ");
            var typeInput = Console.ReadLine();

        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string ItemType { get; set; }
    }

}

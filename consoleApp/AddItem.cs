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
            
            var frameBodySpace = new FrameBodySpace();
            var frameFooter = new FrameFooter();
            var applicationCommands = new ApplicationCommands();
            int leftSpaces = 4;
            string leftPadding = new string(' ', leftSpaces);

            // Deserialize JSON file
            var json = File.ReadAllText(path: "itemType.json");
            var itemTypes = JsonConvert.DeserializeObject<List<ItemType>>(json);




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
            var input = Console.ReadLine().ToLower();
            string UUID = Guid.NewGuid().ToString();



            bool containsId = itemTypes.Any(p => p.id.ToString() == input);
            bool containsItemType = itemTypes.Any(p => p.itemType.ToLower() == input);

            if (containsId || containsItemType)
            {
                var convertedInput = from iT in itemTypes
                                     where iT.id.ToString() == input
                                     select iT.itemType;

                var strConvertedInput = string.Join(",", convertedInput.ToArray());

                Console.Write("\r\nEnter Item Name: ");
                var itemName = Console.ReadLine().ToString();
                Console.Write("\r\nEnter Item's Current Location: ");
                var itemLocation = Console.ReadLine().ToString();;
                try
                {
                    Console.Write("\r\nEnter Item's Estimated Value: $");
                    int value = Convert.ToInt32(Console.ReadLine());
                    if (value.Equals(value))
                    {
                        Console.WriteLine("Item Entered Successfully.");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();

                        var invalidUserInput = new ExitProgram();
                        invalidUserInput.Run();
                    }
                    UserItemData userItemData = new UserItemData
                    {
                        guid = UUID,
                        itemType = strConvertedInput,
                        itemName = itemName,
                        itemLocation = itemLocation,
                        value = value,

                    };

                    // serialize JSON to a string and then write string to a file
                    File.WriteAllText("userItemdata.json", JsonConvert.SerializeObject(userItemData));

                    //open file stream
                    using (StreamWriter file = File.CreateText(path: "userItemdata.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        //serialize object directly into file stream
                        serializer.Serialize(file, userItemData);
                    }
                }
                catch
                {
   
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Please attempt to re-enter inventory item. Enter integer (number) only for value");
                    var invalidUserInput = new ExitProgram();
                    invalidUserInput.Run();
                }

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

        public class UserItemData
        {
            public string guid { get; set; }
            public string itemType { get; set; }
            public string itemName { get; set; }
            public string itemLocation { get; set; }
            public int value { get; set; }


        }

    }


}



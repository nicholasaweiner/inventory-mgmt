using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using consoleApp.AppFrame;
using consoleApp.Commands;
using shortid;
using shortid.Configuration;

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

            // Frame Header
            frameHeader.BlankHeader();

            // Application Frame - Add Item Body
            applicationCommands.AddItemCommands();

            // Item Types
            applicationCommands.AddItemType();
            
            // Frame Body Space
            frameBodySpace.Run();


            // Default Application Frame Footer
            frameFooter.Run();


            Console.Write("\r\nSelect an option: ");
            var input = Console.ReadLine().ToLower();

            // UUID - ShortId 
            var options = new GenerationOptions(useSpecialCharacters: false);
            string UUID = ShortId.Generate(options);

            bool containsId = itemTypes.Any(p => p.id.ToString() == input);
            bool containsItemType = itemTypes.Any(p => p.itemType.ToLower() == input);

            if ((!containsId) && (!containsItemType))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input.");
                var invalidUserInput = new ExitProgram();
                invalidUserInput.Run();
            }

            Console.Write("\r\nWhat is your name? ");
            var userName = Console.ReadLine().ToString();


            var convertedInput =    from iT in itemTypes
                                    where (iT.id.ToString() == input) || (iT.itemType.ToString().ToLower() == input)
                                    select iT.itemType;

            var strConvertedInput = string.Join(",", convertedInput.ToArray());


            Console.Write($"\r\nEnter name of {strConvertedInput.ToLower()}: ");
            var itemName = Console.ReadLine().ToString();

            Console.Write($"\r\nEnter {strConvertedInput.ToLower()}'s current location: ");


            var itemLocation = Console.ReadLine().ToString();;
            Console.Write($"\r\nEnter {strConvertedInput.ToLower()}'s estimated value: $");
            var itemValue = Console.ReadLine();
            if (itemValue.Equals(itemValue))
            {
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine($"{strConvertedInput} was successfully entered into inventory.");
                Console.WriteLine($"Entry ID: \"{UUID}\" ");
                var exit = new ExitProgram();
                exit.Run();
            }
            else
            {
                Console.Clear();
                var invalidUserInput = new ExitProgram();
                invalidUserInput.Run();

            }

            Console.Clear();


            UserItemData userItemData = new()
            {
                guid = UUID,
                userName = userName,
                itemType = strConvertedInput,
                itemName = itemName,
                itemLocation = itemLocation,
                itemValue = itemValue,

            };


            // serialize JSON to a string and then write string to a file
            File.WriteAllText("userItemData.json", JsonConvert.SerializeObject(userItemData));

            //open file stream

            using StreamWriter file = File.CreateText(path: "userItemData.json");
            JsonSerializer serializer = new JsonSerializer();
            //serialize object directly into file stream
            serializer.Serialize(file, userItemData);
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
            public string userName { get; set; }
            public string itemType { get; set; }
            public string itemName { get; set; }
            public string itemLocation { get; set; }
            public string itemValue { get; set; }

        }

    }




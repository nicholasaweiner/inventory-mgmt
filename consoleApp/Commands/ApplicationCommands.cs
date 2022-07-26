using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using consoleApp.AppFrame;
using System.Reflection;

namespace consoleApp.Commands
{
    class ApplicationCommands
    {
        public void AddItemCommands()
        {
            // Deserialize JSON file

            var json = File.ReadAllText(path: "prompts.json");

            var prompts = JsonConvert.DeserializeObject<List<Prompts>>(json);

            // Use Reflection

            string strmsg = string.Empty;

                Prompts p = prompts[0];
                GetPropertyValues(p);
                // Console.WriteLine(strmsg);
        }

        public void EditItemCommands()
        {
            // Deserialize JSON file

            var json = File.ReadAllText(path: "prompts.json");

            var prompts = JsonConvert.DeserializeObject<List<Prompts>>(json);

            // Use Reflection

            string strmsg = string.Empty;

            Prompts p = prompts[1];
            GetPropertyValues(p);
            // Console.WriteLine(strmsg);
        }

        public void RemoveItemCommands()
        {
            // Deserialize JSON file

            var json = File.ReadAllText(path: "prompts.json");

            var prompts = JsonConvert.DeserializeObject<List<Prompts>>(json);

            // Use Reflection

            string strmsg = string.Empty;

            Prompts p = prompts[2];
            GetPropertyValues(p);
            // Console.WriteLine(strmsg);
        }

        public void BrowseItemsCommands()
        {
            // Deserialize JSON file

            var json = File.ReadAllText(path: "prompts.json");

            var prompts = JsonConvert.DeserializeObject<List<Prompts>>(json);

            // Use Reflection

            string strmsg = string.Empty;

            Prompts p = prompts[3];
            GetPropertyValues(p);
            // Console.WriteLine(strmsg);
        }

        private static void GetPropertyValues(Prompts p)
        {
            int leftSpaces = 4;
            string leftPadding = new string(' ', leftSpaces);

            Type type = p.GetType();
            //Console.WriteLine("Type is: {0}", type.Name);

            PropertyInfo[] props = type.GetProperties();
            //Console.WriteLine("Properties (N = {0}):", props.Length);

            foreach (var prop in props)
            {
                var frameBodySpace = new FrameBodySpace();
                var propStr = prop.GetValue(p).ToString();
                var charFreq = propStr.Length;
                int multipler = 69;
                int rightSpaces = multipler - charFreq;
                string rightPadding = new string(' ', rightSpaces);
                Console.WriteLine($"|{leftPadding}{prop.GetValue(p)}{rightPadding}|");
                frameBodySpace.Run();
            }
        }

        public void AddItemType()
        {

            int leftSpaces = 4;
            string leftPadding = new string(' ', leftSpaces);

            // Deserialize JSON file

            var json = File.ReadAllText(path: "itemType.json");

            var itemTypes = JsonConvert.DeserializeObject<List<ItemType>>(json);

            foreach (var el in itemTypes)
            {
                var charFreq = el.itemType.Length;
                int multipler = 65;
                int rightSpaces = multipler - charFreq;
                string rightPadding = new string(' ', rightSpaces);
                Console.WriteLine($"|{leftPadding}{el.id} - {el.itemType}{rightPadding}|");
            }

        }

        public class ItemType
        {
            public int id { get; set; }
            public string itemType { get; set; }
        }

        public class Prompts
        {
            public string heading { get; set; }
            public string subheading { get; set; }
        }

        public class Root
        {
            public Prompts prompts { get; set; }
        }
    }
}

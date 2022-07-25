using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using consoleApp.AppFrame;
using System.Reflection;

namespace consoleApp.Commands
{
    class ApplicationCommands
    {
        public class AddItem
        {
            private string heading;
            private string subheading;

            public AddItem(string head, string subhead)
            {
                heading = head;
                subheading = subhead;
            }

            public string Head
            { get { return heading; }
            }

            public string Subhead
            {   get { return subheading; }
                set { subheading = value; } }
        }

        public class BrowseItems
        {
            public string heading { get; set; }
            public string subheading { get; set; }
        }

        public class EditItem
        {
            public string heading { get; set; }
            public string subheading { get; set; }
        }

        public class Prompts
        {
            public AddItem addItem { get; set; }
            public EditItem editItem { get; set; }
            public RemoveItem removeItem { get; set; }
            public BrowseItems browseItems { get; set; }
        }

        public class RemoveItem
        {
            public string heading { get; set; }
            public string subheading { get; set; }
        }

        public class Root
        {
            public Prompts prompts { get; set; }
        }

        public void Run()
        {
            var frameBodySpace = new FrameBodySpace();

            // Deserialize JSON file

            var json = File.ReadAllText("/Users/home/inv-mgmt/consoleApp/Commands/prompts.json");

            var roots = JsonConvert.DeserializeObject<List<Root>>(json);

            List<AddItem> addItems = JsonConvert.DeserializeObject<List<AddItem>>(json);


            // Use Reflection

            string strmsg = string.Empty;
            foreach (var el in addItems)
            {
                GetPropertyValues(el);
                Console.WriteLine(strmsg);
            }

            //foreach (AddItem el in addItems)
            //{
            //    var charFreq = el.heading.Count();
            //    int multipler = 69;
            //    int numSpaces = multipler - charFreq;
            //    string space = new string(' ', numSpaces);
            //    Console.WriteLine($"│    {el.heading}" + $"{space}|");
            //    frameBodySpace.Run();
            //    Console.WriteLine($"│    {el.subheading}" + $"{space}|");
            //    frameBodySpace.Run();
            //}

            //foreach (Root el in roots)
            //{
            //    // Find and return any string in el.prompts


            //}
        }

        private static void GetPropertyValues(AddItem el)
        {
            Type type = el.GetType();
            Console.WriteLine("Type is: {0}", type.Name);
            PropertyInfo[] props = type.GetProperties();
            Console.WriteLine("Properties (N = {0}):", props.Length);
            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                    Console.WriteLine("{0} ({1}): {2}", prop.Name, prop.PropertyType.Name, prop.GetValue(el));
                else
                    Console.WriteLine("{0} ({1}): <Indexed>", prop.Name, prop.PropertyType.Name);
            //****  Not Getting Value returned for prop.GetValue(el) ****;
        }
    }
}

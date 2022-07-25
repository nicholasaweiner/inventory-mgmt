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
            private string head;
            private string subhead;

            public AddItem(string head, string subhead)
            {
                this.head = head;
                this.subhead = subhead;
            }

            public string Heading
            {
                get { return head; }
                set { head = value; }
            }

            public string Subheading
            {   get { return subhead; }
                set { subhead = value; } }
        }

        public class BrowseItems
        {
            private string head;
            private string subhead;

            public BrowseItems(string head, string subhead)
            {
                this.head = head;
                this.subhead = subhead;
            }

            public string Heading
            {
                get { return head; }
                set { head = value; }
            }

            public string Subheading
            {
                get { return subhead; }
                set { subhead = value; }
            }
        }

        public class EditItem
        {
            private string head;
            private string subhead;

            public EditItem(string head, string subhead)
            {
                this.head = head;
                this.subhead = subhead;
            }

            public string Heading
            {
                get { return head; }
                set { head = value; }
            }

            public string Subheading
            {
                get { return subhead; }
                set { subhead = value; }
            }
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
            private string head;
            private string subhead;

            public RemoveItem(string head, string subhead)
            {
                this.head = head;
                this.subhead = subhead;
            }

            public string Heading
            {
                get { return head; }
                set { head = value; }
            }

            public string Subheading
            {
                get { return subhead; }
                set { subhead = value; }
            }
        }

        public class Root
        {
            public Prompts prompts { get; set; }
        }

        public void AddItemCommands()
        {
            // Deserialize JSON file

            var json = File.ReadAllText(path: "prompts.json");

            var roots = JsonConvert.DeserializeObject<List<Root>>(json);


            // Use Reflection

            string strmsg = string.Empty;
            foreach (var r in roots)
            {
                GetPropertyValues(r.prompts.addItem);
                // Console.WriteLine(strmsg);

            }
        }

        private static void GetPropertyValues(AddItem el)
        {
            int leftSpaces = 4;
            string leftPadding = new string(' ', leftSpaces);

            Type type = el.GetType();
            //Console.WriteLine("Type is: {0}", type.Name);

            PropertyInfo[] props = type.GetProperties();
            //Console.WriteLine("Properties (N = {0}):", props.Length);

            foreach (var prop in props)
            {
                var frameBodySpace = new FrameBodySpace();
                var propStr = prop.GetValue(el).ToString();
                var charFreq = propStr.Length;
                int multipler = 69;
                int rightSpaces = multipler - charFreq;
                string rightPadding = new string(' ', rightSpaces);
                Console.WriteLine($"|{leftPadding}{prop.GetValue(el)}{rightPadding}|");
                frameBodySpace.Run();
            }
        }
    }
}

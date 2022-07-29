using System;
namespace consoleApp.AppFrame
{
    class FrameHeader
    {
        public void Run()
        {
            Console.Clear();

            Console.WriteLine($"┌─────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine($"│                                                                         │");
            Console.WriteLine($"│   Inventory Management Application                                      │");
            Console.WriteLine($"│                                                                         │");
            Console.WriteLine($"│   Console App built by Nick Weiner using C#                             │");
            Console.WriteLine($"|                                                                         |");
        }

        public void BlankHeader()
        {
            Console.Clear();

            Console.WriteLine($"┌─────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine($"│                                                                         │");

        }
    }
}


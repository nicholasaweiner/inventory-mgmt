using System;
namespace consoleApp.AppFrame
{
    class FrameBodySpace
    {
        public void Run()
        {
            int x = 73;
            string frameBodyLine = new string(' ', x);

            Console.WriteLine($"|{frameBodyLine}|");
        }
    }
}


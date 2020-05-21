using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.MessageHelper
{
    public class DialogHelper
    {
        public static void Dialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n" + message + "\n");
            Console.ResetColor();
        }

        public static void Dialog(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}

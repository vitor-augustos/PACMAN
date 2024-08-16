using System;

namespace pacman.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var screen = new Screen();
            screen.Map.Initialize(32,32);

            foreach(var col in screen.Map.Elements)
            {

                System.Console.Write(col.Draw().Result);
                
            }
        }
    }
}

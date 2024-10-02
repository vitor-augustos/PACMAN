using System;
using System.Threading;
using System.Xml.Linq;

namespace pacman.console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var screen = new Screen();

            var cancellationToken = new CancellationTokenSource();

            screen.Map.Initialize(32, 32, cancellationToken);

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                Console.SetCursorPosition(0, 0);
                //System.Console.Clear();
                //foreach (var col in screen.Map.Elements)
                //{

                //    System.Console.Write(col?.DrawAsChar().Result);
                //}

                for (int i = 0; i < screen.Map.Elements.GetLength(0); i++) // Loop over rows
                {
                    for (int j = 0; j < screen.Map.Elements.GetLength(1); j++) // Loop over columns
                    {
                        var currentElement = screen.Map.Elements[j, i];
                        // Do something with currentElement
                        var characterInfo = currentElement?.DrawAsChar().Result;
                        if (characterInfo != null)
                        {
                            Console.ForegroundColor = characterInfo.Color;
                            Console.Write(characterInfo?.Character);
                        }
                    }
                    Console.WriteLine();
                }


                Thread.Sleep(500);
                if (System.Console.KeyAvailable)
                {
                    System.ConsoleKeyInfo keyPressed = System.Console.ReadKey(false);
                    if (keyPressed.Key == System.ConsoleKey.Escape)
                    {
                        cancellationToken.Cancel();
                    }

                    screen.UserInput(keyPressed.Key);
                }
            }
        }
    }
}

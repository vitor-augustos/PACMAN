using System.Threading;

namespace pacman.console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var screen = new Screen();

            var cancellationToken = new CancellationTokenSource();

            screen.Map.Initialize(32, 1, cancellationToken);

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                System.Console.Clear();
                foreach (var col in screen.Map.Elements)
                {
                    System.Console.Write(col?.DrawAsChar().Result);
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

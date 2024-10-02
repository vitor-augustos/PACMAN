using pacman.logic;
using pacman.logic.Drawing;
using System.Threading.Tasks;

public class Food : IElement
{
    public Position Position { get; set; }
    public Task<CharDrawing> DrawAsChar()
    {
        return Task.FromResult(new CharDrawing('.', System.ConsoleColor.Gray));
    }
}
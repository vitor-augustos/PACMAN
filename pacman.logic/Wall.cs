

using pacman.logic;
using System.Threading.Tasks;

public class Wall : IElement
{
    public Position Position { get; set; }
    public Task<char> DrawAsChar()
    {
        return Task.FromResult('█');
    }
}
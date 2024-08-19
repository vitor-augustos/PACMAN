using pacman.logic;
using System.Threading.Tasks;

public interface IElement
{
    Task<char> DrawAsChar();
    Position Position { get; set; }
}
using pacman.logic;
using pacman.logic.Drawing;
using System.Threading.Tasks;

public interface IElement
{
    Task<CharDrawing> DrawAsChar();
    Position Position { get; set; }
}
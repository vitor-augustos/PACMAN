using System.Threading.Tasks;

namespace pacman.logic
{
    public interface IPlayableElement
    {
        Task UserInput(System.ConsoleKey keyPressed);
    }
}

using pacman.logic;
using System.Threading;
using System.Threading.Tasks;

public class Map
{
    public IElement[,] Elements { get; set; }
    public IPlayableElement Character { get; private set; }
    private IElement _previousElementInPlace = null;
    private int _maxWidth;
    private int _maxHeight;

    public Task Initialize(int width, int height, CancellationTokenSource cancellationToken)
    {
        _maxWidth = width;
        _maxHeight = height;

        Elements = new IElement[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int k = 0; k < height; k++)
            {
                Elements[i, k] = new Food();
            }
        }

        var position = new Position(0, 0);
        var pacman = new Pacman(this, position, cancellationToken);
        Character = pacman;
        Elements[position.Horizontal, position.Vertical] = pacman;
        return Task.CompletedTask;
    }

    public bool TryMoveRight(IElement element)
    {
        //if next move could reach the map limit,then deny move
        if (element.Position.Horizontal + 1 >= _maxWidth)
            return false;

        //fill empty space with the previous element in that position (before the player be there)
        Elements[element.Position.Horizontal, element.Position.Vertical] = _previousElementInPlace;

        //set the new position
        element.Position.Horizontal += 1;

        //store the previous element in that position
        _previousElementInPlace = Elements[element.Position.Horizontal, element.Position.Vertical];

        //replace position with the player element
        Elements[element.Position.Horizontal, element.Position.Vertical] = element;

        //notify allowed movement
        return true;
    }

    //TODO: implement TryMoveLeft function
}
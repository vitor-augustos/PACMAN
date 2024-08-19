using pacman.logic;
using System.Threading;
using System.Threading.Tasks;

public class Pacman : IElement, IPlayableElement
{
    public Direction Direction { get; set; } = Direction.Stopped;
    public Position Position { get; set; }
    private readonly CancellationTokenSource _cancellationToken;
    private Map _map;


    public Pacman(Map map, Position position, CancellationTokenSource cancellationToken)
    {
        _map = map;
        _cancellationToken = cancellationToken;
        Position = position;

        Task.Run(() => StartMoving());
    }

    private async Task StartMoving()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            await MoveOneStep();
            Thread.Sleep(500);
        }
    }

    public Task<char> DrawAsChar()
    => this.Direction switch
    {
        Direction.Up => Task.FromResult('v'),
        Direction.Down => Task.FromResult('^'),
        Direction.Right => Task.FromResult('<'),
        Direction.Left => Task.FromResult('>'),
        _ => Task.FromResult('x')
    };

    private Task MoveOneStep()
    {
        if (_cancellationToken.IsCancellationRequested)
        {
            Direction = Direction.Stopped;
        }

        switch (Direction)
        {
            case Direction.Stopped:
                break;

            case Direction.Right:
                if (!_map.TryMoveRight(this))
                {
                    Direction = Direction.Stopped;
                }
                break;

            case Direction.Left:
                if (!_map.TryMoveLeft(this))
                {
                    Direction = Direction.Stopped;
                }
                break;

            case Direction.Up:
                break;

            case Direction.Down:
                break;

            default:
                break;
        }

        return Task.CompletedTask;
    }

    public Task UserInput(System.ConsoleKey keyPressed)
    {
        if (keyPressed == System.ConsoleKey.RightArrow)
        {
            Direction = Direction.Right;
        }

        if (keyPressed == System.ConsoleKey.LeftArrow)
        {
            Direction = Direction.Left;
        }

        return Task.CompletedTask;
    }
}
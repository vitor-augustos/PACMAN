using pacman.logic;
using pacman.logic.Drawing;
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

    public Task<CharDrawing> DrawAsChar()
    => this.Direction switch
    {
        Direction.Up => Task.FromResult(new CharDrawing('\u19A2', System.ConsoleColor.Yellow)),
        Direction.Down => Task.FromResult(new CharDrawing('\u1985', System.ConsoleColor.Yellow)),
        Direction.Right => Task.FromResult(new CharDrawing('\u03F2', System.ConsoleColor.Yellow)),//𐒨
        Direction.Left => Task.FromResult(new CharDrawing('\u037B', System.ConsoleColor.Yellow)),//𐒧
        _ => Task.FromResult(new CharDrawing('x', System.ConsoleColor.Yellow))
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
                if (!_map.TryMoveUp(this))
                {
                    Direction = Direction.Stopped;
                }
                break;

            case Direction.Down:
                if (!_map.TryMoveDown(this))
                {
                    Direction = Direction.Stopped;
                }
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

        if (keyPressed == System.ConsoleKey.UpArrow)
        {
            Direction = Direction.Up;
        }

        if (keyPressed == System.ConsoleKey.DownArrow)
        {
            Direction = Direction.Down;
        }

        return Task.CompletedTask;
    }
}
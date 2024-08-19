namespace pacman.logic
{
    public class Position
    {
        public int Horizontal { get; set; } = 0;
        public int Vertical { get; set; } = 0;

        public Position(int horizontal, int vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }
    }
}

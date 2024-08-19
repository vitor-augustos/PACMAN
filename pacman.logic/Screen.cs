public class Screen
{
    public Map Map { get; set; } = new();

    public void UserInput(System.ConsoleKey keyPressed)
    {
        Map.Character.UserInput(keyPressed);
    }
}
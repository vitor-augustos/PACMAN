using System.Threading.Tasks;

public class Pacman : IElement
{
    public Task<char> Draw()
   {
     return Task.FromResult('C');
   }
}
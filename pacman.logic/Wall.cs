

using System.Threading.Tasks;

public class Wall : IElement
{
   public Task<char> Draw()
   {
        return Task.FromResult('█');
   }
}
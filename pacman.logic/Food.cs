using System.Threading.Tasks;

public class Food : IElement
{
  public Task<char> Draw()
   {
        return Task.FromResult('.');
   }
}
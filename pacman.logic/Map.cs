

using pacman.logic;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Map
{
     public IList<IElement> Elements {get;set;}

     public Task Initialize(int width, int height)
     {
        Elements = new List<IElement>(width);

        for(int i = 1; i<=width; i++)
        {
            Elements.Add(new Food());
        }


        Elements[0] = new Pacman();
        return Task.CompletedTask;
     }
}
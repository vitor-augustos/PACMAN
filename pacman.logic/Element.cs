using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman.logic
{
    public abstract class Element : IElement
    {
        public Task<char> Draw()
        {
            throw new NotImplementedException();
        }
    }
}

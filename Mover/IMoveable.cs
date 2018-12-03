using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrains;

namespace Mover
{
    public interface IMoveable
    {
        bool Move(int id, string steps, Terrain terrain, ref Direction direction, ref Point position);
    }
}

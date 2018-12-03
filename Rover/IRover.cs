using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrains;

namespace Rover
{
    public interface IRover
    {
        int X
        {
            get;
        }
        int Y
        {
            get;
        }
        char Orientation
        {
            get;
        }
        bool Move(int id, string steps);

        string State
        {
            get;
        }

        Terrain CurrentTerrain
        {
            get;
            set;
        }

    }
}

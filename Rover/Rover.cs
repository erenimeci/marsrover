using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Mover;
using Terrains;

namespace Rover
{
    public class Rover : IRover
    {
        private Point position;
        private Direction direction;
        private IMoveable myMover;
        private Terrain  myTerrain;

        public Rover()
        {
            position = new Point();
            direction = Direction.N;

            myMover = new DumbMover();
        }

        public Rover(int x, int y, char d, IMoveable mover)
        {
            position.X = x;
            position.Y = y;
            direction = (Direction)Enum.Parse(typeof(Direction), d.ToString());

            myMover = mover;
        }

        public bool Move(int id, string steps)
        {
            bool moved = myMover.Move(id, steps, CurrentTerrain, ref direction, ref position);
            myTerrain.ChangeRoverLocation(id, position);

            return moved;
        }

        public int X
        {
            get
            {
                return position.X;
            }
        }
        public int Y
        {
            get
            {
                return position.Y;
            }
        }
        public char Orientation
        {
            get
            {
                return (char)direction.ToString()[0];
            }
        }

        public string State
        {
            get
            {
                return X.ToString() + " " + Y.ToString() + " " + Orientation.ToString();
            }
        }

        public Terrain CurrentTerrain
        {
            get
            {
                return myTerrain;
            }
            set
            {
                myTerrain = value;
            }
        }
    }
}

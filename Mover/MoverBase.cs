using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrains;

namespace Mover
{
    public enum Direction
    {
        N,
        E,
        S,
        W
    }

    public abstract class Mover : IMoveable
    {

        private void Move_Internal(int id, string steps, Terrain terrain, ref Direction direction, ref Point position)
        {
            for (int i = 0; i < steps.Length; i++)
            {
                switch (steps[i])
                {
                    case 'L':
                        direction = (Direction)((int)direction - 1);
                        if ((int)direction == -1)
                        {
                            direction = Direction.W;
                        }
                        break;
                    case 'R':
                        direction = (Direction)(((int)direction + 1) % 4);
                        break;
                    case 'M':
                        switch (direction)
                        {
                            case Direction.N:
                                position.Y++;
                                break;
                            case Direction.S:
                                position.Y--;
                                break;
                            case Direction.E:
                                position.X++;
                                break;
                            case Direction.W:
                                position.X--;
                                break;
                        }
                        break;
                }
            }

            terrain.ChangeRoverLocation(id, position);
        }

        protected bool TryMove(int id, string steps, Terrain terrain, Direction tryDirection, Point tryPosition)
        {
            for (int i = 0; i < steps.Length; i++)
            {
                switch (steps[i])
                {
                    case 'L':
                        tryDirection = (Direction)((int)tryDirection - 1);
                        if ((int)tryDirection == -1)
                        {
                            tryDirection = Direction.W;
                        }
                        break;
                    case 'R':
                        tryDirection = (Direction)(((int)tryDirection + 1) % 4);
                        break;
                    case 'M':
                        switch (tryDirection)
                        {
                            case Direction.N:
                                tryPosition.Y++;
                                break;
                            case Direction.S:
                                tryPosition.Y--;
                                break;
                            case Direction.E:
                                tryPosition.X++;
                                break;
                            case Direction.W:
                                tryPosition.X--;
                                break;
                        }
                        break;
                    default:
                        return false;
                }

                if (terrain.HasRover(id, tryPosition) || !terrain.IsWithinPlane(tryPosition))
                {
                    return false;
                }
            }

            return true;
        }

        public virtual bool Move(int id, string steps, Terrain terrain, ref Direction direction, ref Point position)
        {
            if (TryMove((1 == id) ? 2 : 1, steps, terrain, direction, position))
            {
                Move_Internal(id, steps, terrain, ref direction, ref position);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

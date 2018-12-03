using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrains;

namespace Mover
{
    public class CleverMover : Mover
    {
        private string GetEffectiveMovementSteps(string steps, Terrain terrain, Direction direction, Point position)
        {
            Direction effectiveDirection = direction;
            Point effectivePosition = position;

            #region Calculating effective displacement
            for (int i = 0; i < steps.Length; i++)
            {
                switch (steps[i])
                {
                    case 'L':
                        effectiveDirection = (Direction)((int)effectiveDirection - 1);
                        if ((int)effectiveDirection == -1)
                        {
                            effectiveDirection = Direction.W;
                        }
                        break;
                    case 'R':
                        effectiveDirection = (Direction)(((int)effectiveDirection + 1) % 4);
                        break;
                    case 'M':
                        switch (effectiveDirection)
                        {
                            case Direction.N:
                                effectivePosition.Y++;
                                break;
                            case Direction.S:
                                effectivePosition.Y--;
                                break;
                            case Direction.E:
                                effectivePosition.X++;
                                break;
                            case Direction.W:
                                effectivePosition.X--;
                                break;
                        }
                        break;
                }
            }
            #endregion

            int xSteps = effectivePosition.X - position.X;
            int ySteps = effectivePosition.Y - position.Y;
            string stepsStringXY = "", stepsStringYX = "";
            Direction? directionToMoveX = null;
            Direction? directionToMoveY = null;

            if (xSteps < 0)
            {
                directionToMoveX = Direction.W;
            }
            else if (xSteps > 0)
            {
                directionToMoveX = Direction.E;
            }
            if (ySteps < 0)
            {
                directionToMoveY = Direction.S;
            }
            else if (ySteps > 0)
            {
                directionToMoveY = Direction.N;
            }
            if (directionToMoveX == null && directionToMoveY == null)
            {
                return string.Empty;
            }

          

            #region First in X direction then in Y direction (stepsStringXY)

            if (directionToMoveX != null)
            {
                if (((int)directionToMoveX - (int)direction) == -1)
                {
                    stepsStringXY += "L";
                    direction = (Direction)((int)direction - 1);
                    if ((int)direction == -1)
                    {
                        direction = Direction.W;
                    }
                }
                else if (((int)directionToMoveX - (int)direction) == 1)
                {
                    stepsStringXY += "R";
                    direction = (Direction)(((int)direction + 1) % 4);
                }
                else if (((int)directionToMoveX - (int)direction) == 2)
                {
                    stepsStringXY += "RR";
                    direction = (Direction)(((int)direction + 2) % 4);
                }
            }

            for (int i = 0; i < Math.Abs(xSteps); i++)
            {
                stepsStringXY += "M";
            }

            if (directionToMoveY != null)
            {
                if (((int)directionToMoveY - (int)direction) == -1)
                {
                    stepsStringXY += "L";
                    direction = (Direction)((int)direction - 1);
                    if ((int)direction == -1)
                    {
                        direction = Direction.W;
                    }
                }
                else if (((int)directionToMoveY - (int)direction) == 1)
                {
                    stepsStringXY += "R";
                    direction = (Direction)(((int)direction + 1) % 4);
                }
            }

            for (int i = 0; i < Math.Abs(ySteps); i++)
            {
                stepsStringXY += "M";
            }

            if (((int)effectiveDirection - (int)direction) == -1)
            {
                stepsStringXY += "L";
                direction = (Direction)((int)direction - 1);
                if ((int)direction == -1)
                {
                    direction = Direction.W;
                }
            }
            else if (((int)effectiveDirection - (int)direction) == 1)
            {
                stepsStringXY += "R";
                direction = (Direction)(((int)direction + 1) % 4);
            }
            else if (((int)effectiveDirection - (int)direction) == 2)
            {
                stepsStringXY += "RR";
                direction = (Direction)(((int)direction + 2) % 4);
            }
            #endregion

            #region First in Y direction then in X direction (stepsStringYX)
            if (directionToMoveY != null)
            {
                if (((int)directionToMoveY - (int)direction) == -1)
                {
                    stepsStringYX += "L";
                    direction = (Direction)((int)direction - 1);
                    if ((int)direction == -1)
                    {
                        direction = Direction.W;
                    }
                }
                else if (((int)directionToMoveY - (int)direction) == 1)
                {
                    stepsStringYX += "R";
                    direction = (Direction)(((int)direction + 1) % 4);
                }
                else if (((int)directionToMoveY - (int)direction) == 2)
                {
                    stepsStringYX += "RR";
                    direction = (Direction)(((int)direction + 2) % 4);
                }
            }

            for (int i = 0; i < Math.Abs(ySteps); i++)
            {
                stepsStringYX += "M";
            }

            if (directionToMoveX != null)
            {
                if (((int)directionToMoveX - (int)direction) == -1)
                {
                    stepsStringYX += "L";
                    direction = (Direction)((int)direction - 1);
                    if ((int)direction == -1)
                    {
                        direction = Direction.W;
                    }
                }
                else if (((int)directionToMoveX - (int)direction) == 1)
                {
                    stepsStringYX += "R";
                    direction = (Direction)(((int)direction + 1) % 4);
                }
            }

            for (int i = 0; i < Math.Abs(xSteps); i++)
            {
                stepsStringYX += "M";
            }

            if (((int)effectiveDirection - (int)direction) == -1)
            {
                stepsStringYX += "L";
                direction = (Direction)((int)direction - 1);
                if ((int)direction == -1)
                {
                    direction = Direction.W;
                }
            }
            else if (((int)effectiveDirection - (int)direction) == 1)
            {
                stepsStringYX += "R";
                direction = (Direction)(((int)direction + 1) % 4);
            }
            else if (((int)effectiveDirection - (int)direction) == 2)
            {
                stepsStringYX += "RR";
                direction = (Direction)(((int)direction + 2) % 4);
            }
            #endregion

         
            if (stepsStringXY.Length < stepsStringYX.Length)
            {
                return stepsStringXY;
            }
            else
            {
                return stepsStringYX;
            }

        }

        public override bool Move(int id, string steps, Terrain terrain, ref Direction direction, ref Point position)
        {
            return base.Move(id, GetEffectiveMovementSteps(steps, terrain, direction, position), terrain, ref direction, ref position);
        }

    }
}

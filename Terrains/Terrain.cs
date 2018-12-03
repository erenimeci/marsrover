using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrains
{
    public class Terrain
    {
        private int mysizeX, mySizeY;
        private IList<Point> myBeacons = new List<Point>();
        private Dictionary<int, Point> myRovers = new Dictionary<int, Point>();

        private static Terrain myTerrain = null;

        private Terrain()
        {
            mysizeX = 0;
            mySizeY = 0;
        }

        private Terrain(int x, int y)
        {
            mysizeX = x;
            mySizeY = y;
        }

        public bool AddBeacon(Point beaconPoint)
        {
            bool flag = false;
            if (mysizeX <= beaconPoint.X && mySizeY <= beaconPoint.Y)
            {
                myBeacons.Add(beaconPoint);
                flag = true;
            }

            return flag;
        }

        public bool HasBeacon(Point location)
        {
            return myBeacons.Contains(location);
        }

        public void ChangeRoverLocation(int id, Point roverPoint)
        {
            if (myRovers.ContainsKey(id))
            {
                myRovers[id] = roverPoint;
            }
            else
            {
                myRovers.Add(id, roverPoint);
            }
        }

        public bool HasRover(int id, Point location)
        {
            if (myRovers.ContainsKey(id))
            {
                return myRovers[id].Equals(location);
            }
            else
            {
                return false;
            }
        }

        public bool IsWithinPlane(Point point)
        {
            bool flag = mysizeX >= point.X && mySizeY >= point.Y;
            return flag;
        }

        public static Terrain GetTerrain()
        {
            if (myTerrain != null)
            {
                return myTerrain;
            }
            else
            {
                int x = 0, y = 0;
                Console.WriteLine("Yüzeyin sağ üst kösesinde ki kortinatını giriniz: (x y)");
                string input = Console.ReadLine();

                if (ProcessInput(input, ref x, ref y))
                {
                    myTerrain = new Terrain(x, y);
                }

                return myTerrain;
            }
        }

        public static bool ProcessInput(string terrain, ref int X, ref int Y)
        {
            try
            {
                string[] xy = terrain.Split(new char[] { ' ' });
                X = int.Parse(xy[0]);
                Y = int.Parse(xy[1]);

                return xy.Length == 2 ? true : false;
            }
            catch
            {
                return false;
            }
        }
    }
}

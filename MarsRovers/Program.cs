using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mover;
using Rover;
using Terrains;

namespace MarsRover
{
    class Program
    {
        public static IRover CreateRover(int id, IMoveable mover)
        {
            int x = 0, y = 0;
            char d = 'U';
            Console.WriteLine("{0}. Roverın Kordinatını ve Yönünü Giriniz: (x y d)", id);
            string input = Console.ReadLine();

            if (ProcessInput(input, ref x, ref y, ref d))
            {
                return new Rover.Rover(x, y, d, mover);
            }
            else
            {
                return null;
            }
        }

        public static bool ProcessInput(string terrain, ref int X, ref int Y, ref char D)
        {
            try
            {
                string[] xy = terrain.Split(new char[] { ' ' });
                X = int.Parse(xy[0]);
                Y = int.Parse(xy[1]);
                D = char.Parse(xy[2]);

                if (D > 90)
                {
                    D = (char)((int)D - 32);
                }

                return (xy.Length == 3) && (D == 'N' || D == 'S' || D == 'E' || D == 'W') ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public static string GetStepsForRover(int id)
        {
            Console.WriteLine("{0}. Roverin hareterlerini giriniz", id);
            string result = Console.ReadLine().ToUpper();
            string steps = (string)result.Clone();

            result = result.Replace("L", "");
            result = result.Replace("R", "");
            result = result.Replace("M", "");

            if (result.Length > 0)
            {
                return string.Empty;
            }
            else
            {
                return steps;
            }
        }

        static void Main(string[] args)
        {
            Terrain terrain = Terrain.GetTerrain();

            IRover dumbRover = CreateRover(1, new DumbMover());
            IRover cleverRover = CreateRover(2, new CleverMover());

            dumbRover.CurrentTerrain = terrain;
            cleverRover.CurrentTerrain = terrain;

            if (!dumbRover.Move(1, GetStepsForRover(1)) || !cleverRover.Move(2, GetStepsForRover(2)))
            {
                Console.WriteLine("Geçersiz hareket");
            }

            Console.WriteLine("==========");
            Console.WriteLine(dumbRover.State);
            Console.WriteLine(cleverRover.State);
            Console.WriteLine("==========");

            Console.ReadKey();
        }
    }
}

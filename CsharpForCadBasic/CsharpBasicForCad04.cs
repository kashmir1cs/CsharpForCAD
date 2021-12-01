using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasicForCad04
{
    class Program
    {
        // Array 
        static void Main(string[] args)
        {
            //SingleDimArray();
            MultiDimArray();
        }

        private static void MultiDimArray()
        {
            // 2 Dim array
            //int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            /*
                        int[,] array2D = new int[3, 2]; // 3 rows, 2 columns
                        array2D[0, 0] = 1;
                        array2D[0, 1] = 2;
                        array2D[1, 0] = 3;
                        array2D[1, 1] = 4;
                        array2D[2, 0] = 5;
                        array2D[2, 1] = 6;

                        // foreach문 활용
                        foreach (int i in array2D)
                        {
                            Console.WriteLine("Value is {0}", i);
                        }

            */
            string[,] cars2D = new string[3, 2] { { "kia", "k5" }, { "hyundai", "avante" }, { "bmw", "520d" } };

            foreach (string s in cars2D)
            {
                Console.WriteLine("Value is {0}", s);
            }
            for (int i =0;i<cars2D.GetLength(0);i++)
            {
                for (int j=0;j<cars2D.GetLength(1);j++)
                {
                    Console.WriteLine("Maker :  {0} / Model : {1} ", cars2D[i, 0], cars2D[i, j]);
                }
            }
            Console.ReadLine();
        }

        private static void SingleDimArray()
        {
            // 1-dim array
            //int[] numbers = new int[] { 2, 3, 5, 7, 8 };
            /*            int[] numbers = new int[5];
                        numbers[0] = 1;
                        numbers[1] = 2;
                        numbers[2] = 6;
                        numbers[3] = 7;
                        numbers[4] = 9;
            */

            /*for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }*/
            //string[] cars = new string[] { "k5", "morning", "santafe" };

/*            string[] cars = new string[4];
            cars[0] = "hyundai";
            cars[1] = "kia";
            cars[2] = "honda";
            cars[3] = "chevy";

            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }

*/            Console.ReadLine();
        }
    }
}


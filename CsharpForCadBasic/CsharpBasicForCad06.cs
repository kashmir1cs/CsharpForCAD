using System;

namespace CsharpBasicForCad06
{
    class Program
    {
        // IF/ Switch
        static void Main(string[] args)
        {
            //IfExercise();
            //IFElseExercise();
            //IfElseIFExercise();
            SwitchExercise();

        }

        private static void SwitchExercise()
        {
            //입력을 받기 위한 변수 선언
            string fruit = "";
            Console.WriteLine("\n Enter your favorite fruit (Exit : x) :");
            fruit = Console.ReadLine().ToLower();
            while (fruit != "x")
            {
                switch (fruit)
                {
                    case "apple":
                        Console.WriteLine("Apple !");
                        break;
                    case "orange":
                        Console.WriteLine("Orange");
                        break;
                    case "mange":
                        Console.WriteLine("Mango");
                        break;
                    default:
                        Console.WriteLine("Banana is the answer");
                        break;
                }
                Console.WriteLine("\n Enter your favorite fruit (Exit : x) :");
                fruit = Console.ReadLine().ToLower();
            }
            Console.WriteLine("Bye");
            Console.ReadKey();

        }

        private static void IfElseIFExercise()
        {
            int ctr = 10;
            int num = GetRandomNumber(9, 12);
            if (num > ctr)
            {
                Console.WriteLine("the number {0} is greater than the counter, ", num);
            }
            else if (num==ctr)
            {
                Console.WriteLine("the number {0} is equal to counter, ", num);
            }
            else
            {
                Console.WriteLine("the number {0} is less than the counter, ", num);
            }
            Console.ReadKey();
        }

        private static void IFElseExercise()
        {
            int ctr = 10;
            int num = GetRandomNumber(1, 20);
            if (num > ctr)
            {
                Console.WriteLine("the number {0} is greater than the counter, ", num);
            }
            else
            {
                Console.WriteLine("the number {0} is less than the counter, ", num);
            }
            Console.ReadKey();
        }

        private static int GetRandomNumber(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }
        private static void IfExercise()
        {
            int ctr = 10;
            int num = GetRandomNumber(1, 20);
            if (num>ctr)
            {
                Console.WriteLine("the number {0} is greater than the counter, ", num);
            }
            Console.ReadKey();

        }
    }
}

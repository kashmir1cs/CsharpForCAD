using System;


namespace CsharpBasicForCad05
{
    // study operators
    class Program
    {
        static void Main(string[] args)
        {
            //AssignOperator();
            //UnaryOperator();
            //PrimaryOperators();
            //EqulityOperators();
            //AdditiveOperators();
            //MulpicativeOperators();
            LogicalCondtionalAndNullOperator();

        }

        private static void LogicalCondtionalAndNullOperator()
        {
            bool x = true;
            bool y = true;
/*
            Console.WriteLine(x & y);
            Console.WriteLine(x && y);
            Console.WriteLine(x || y);
            Console.WriteLine(x | y);

*/
            y = false;
/*
            Console.WriteLine(x & y);
            Console.WriteLine(x && y);
            Console.WriteLine(x || y);
            Console.WriteLine(x | y);
            Console.WriteLine(x ^ y);

*/
            Console.WriteLine(x ^ y);

            y = true;
            if (x&&y)
            {
                Console.WriteLine("result of x&&y is true");
            }

            int? i = null;
            int j = i ?? 5;
            Console.WriteLine(j);

            int c = 2;
            string msg1 = "Hi";
            string msg2 = "Hello";
            Console.WriteLine(c == 1 ? msg1 : msg2);

            Console.ReadLine();
        }

        private static void MulpicativeOperators()
        {
            Console.WriteLine(2 * 5);
            Console.WriteLine(12 / 5);
            Console.WriteLine(10 % 3);
        }

        private static void AdditiveOperators()
        {
            int x = 2;
            int y = 2;
            Console.WriteLine("x + y is {0}", x + y);
            string s1 = "hi ";
            string s2 = "world";
            Console.WriteLine(s1+s2);
            Console.ReadLine();
        }

        private static void EqulityOperators()
        {
            int x = 2;
            int y = 2;
            if (x==y)
            {
                Console.WriteLine("x is {0}",x);
                Console.WriteLine("y is {0}",y);
                Console.WriteLine("x equals y");
            }
            
            y = 3; // change y 
            Console.WriteLine("if y is :{0} ",y);
            if (x != y)
            {
                Console.WriteLine("x equals y");
            }
            
            Console.ReadLine();
        }

        private static void PrimaryOperators()
        {
            // Member access
            Line ln = new Line();
            ln.ColorIndex = 1;

            // Array and indexer access
            string[] fruits = new string[2];
            fruits[0] = "Apple";
            fruits[1] = "Mango";
            string favoriteFruit = fruits[1];
            Console.WriteLine("Favorite fruit is : " + favoriteFruit);

            // Post-Increment
            int x = 3;
            Console.WriteLine(" x after \"x++\" when x = 3  is  : " + x++);
            Console.WriteLine(" result of \"x++\" is : " + x);

            // Post-Decrement
            int y = 5;
            Console.WriteLine(" y after \"y--\" when y = 5  is : " + y--);
            Console.WriteLine(" result of \"y--\" is : " + y);
            Console.ReadLine();
        }

        class Line
        {
            public int ColorIndex { get; set; }
        }

        private static void UnaryOperator()
        {
            int x = 0;
            //Console.WriteLine(++x);

            x = 5;
            Console.WriteLine(--x); // 1을 뺀 값을 출력 x++일경우 원래 값 (x=5)을 출력한 후 x에서 1을 뺌
            Console.ReadLine();
        }

        private static void AssignOperator()
        {
            int x = 2;
            //Console.WriteLine(x);
            int y = 1;
/*
            Console.WriteLine(x += y);
            Console.WriteLine(x -= y);

*/          
            y = 3;
            //Console.WriteLine(x *= y);
            y = 8;

            y = 2;
            Console.WriteLine(x /= y);
            Console.ReadLine();

        }
    }
}

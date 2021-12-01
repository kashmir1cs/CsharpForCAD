using System;

namespace CsharpBasicForCad07
{
    // Loop Exercise
    class Program
    {
        static void Main(string[] args)
        {
            //ForLoopExercise();
            //ForEachLoopExercise();
            //WhileLoopExercise();
            DoWhileLoopExercise();

        }

        private static void DoWhileLoopExercise()
        {
            int ctr = 0;
            do
            {
                Console.WriteLine("value : " + ctr.ToString());
                ctr += 1;
            }
            while (ctr < 10001);

        }

        private static void WhileLoopExercise()
        {
            int ctr = 1;
            while (ctr <=10)
            {
                Console.WriteLine(ctr.ToString());
                ctr += 1;

            }
        }

        class cadCircle
        {
            public int ID { get; set; }
            public int Radius { get; set; }
            public string Color { get; set; }
        }

        private static void ForEachLoopExercise()
        {
            cadCircle c1 = new cadCircle();
            c1.ID = 1234;
            c1.Color = "red";
            c1.Radius = 1;

            cadCircle c2 = new cadCircle();
            c2.ID = 12;
            c2.Color = "cyan";
            c2.Radius = 3;
            cadCircle c3 = new cadCircle();
            c3.ID = 134;
            c3.Color = "blue";
            c3.Radius = 5;
            List<cadCircle> circles = new List<cadCircle>();
            circles.Add(c1);
            circles.Add(c2);
            circles.Add(c3);

            foreach (cadCircle cir in circles)
            {
                Console.WriteLine("ID :" + cir.ID);
                Console.WriteLine("Radius :" + cir.Radius);
                Console.WriteLine("Color :" + cir.Color);
            }

        }

        private static void ForLoopExercise()
        {
            for (int i=0;i<=10;i++)
            {
                Console.WriteLine("Number is {0}", i);
            }
        }
    }
}

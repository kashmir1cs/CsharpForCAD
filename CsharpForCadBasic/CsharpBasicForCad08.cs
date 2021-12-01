using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasicForCad08
{
    class Program
    {
        // debugging
        static void Main(string[] args)
        {
            
            //DisplayNumbers(); //index 번호 에러 - 중단점 설정후 조사식 추가를 통한 에러 원인 확인하기
            //DebugExercise2();
            DebugExercise3();
        }

        private static void DebugExercise3()
        {
            int amount = 10000;
            double interestRate = 3.0;
            double result = 0.0;
            result = CalculatePayment(amount, interestRate);
            Console.WriteLine(" pay for month " + result);
            Console.ReadLine();

        }

        private static double CalculatePayment(int amountToCalculate, double percentRate)
        {
            double iPercentDivisor = 100;
            double result = 0.0;
            result = amountToCalculate *(1+ (percentRate/iPercentDivisor));
            result = amountToCalculate / (double)PaymentType.Monthly;
            return result;
        }
        public enum PaymentType
        {
            Quarterly=4,
            Monthly=12,
            Weekly=52
        }

        private static void DebugExercise2()
        {
            Console.Write("Enter name to validate membership :");
            string name = Console.ReadLine();
            bool isMember = CheckMemberShip(name);
            if (isMember)
            {
                Console.WriteLine("Yes " + name + " is a member");
            }
            else
            {
                Console.WriteLine("No " + name + " is not a member");
            }
            Console.ReadLine();
        }

        private static bool CheckMemberShip(string name)
        {
            string[] members = new string[] { "KIM", "LEE", "park", "choi" };
            bool isMember = false;
            foreach (string s in members)
            {
                if (s.ToLower()==name.ToLower())
                {
                    isMember = true;
                }
            }
            return isMember;
        }

        private static void DisplayNumbers()
        {
            int[] numbers = new int[5] { 4, 6, 3, 2, 9 };
            for (int i =1;i<numbers.Length;i++) //index는 0부터 시작해야함 
            {
                Console.WriteLine("value is " + numbers[i]);
            }
            Console.ReadLine();
        }
    }
}

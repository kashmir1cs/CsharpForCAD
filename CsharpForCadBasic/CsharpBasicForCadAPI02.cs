using System;


namespace CsharpBasicForCad02
{
    class Program
    {
        static void Main(string[] args)
        {
            // 변수 타입 이해하기 : float,double,decimal
            // decimal : 정확도 높음 금융 계산등에 주로 이용, range는 좁으나 정확도가 좋음
            // float 이해하기
            float x = 4.6f; //f또는 F 반드시 붙일 것
            Console.WriteLine(x);

            double dbNum = 3.5; //F또는 f 필요없음
            Console.WriteLine(dbNum);
            double dbNum2 = 3D; //integer
            Console.WriteLine(dbNum2);
            decimal money = 100.5m; //suffix 필요
            Console.WriteLine(money);
            decimal totalamount = money * 100;
            Console.WriteLine(totalamount);
        }
    }
}

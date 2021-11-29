using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //sbyte 정수형자료
            sbyte sb = -128;
            sbyte sb2 = 127;

            short sh = -32768;
            short sh2 = 32767;
            // escape 문자 활용하기
            Console.WriteLine(" sbyte 하한 : \""+sb.ToString()+ "\"   sbyte 상한 : \"" + sb2.ToString()+ "\" short 하한: \"" + sh.ToString()+ "\" short 상한 :\"" + sh2.ToString()+"\""+"\n");
            int i1 = -2147483648;
            int i2 = 2147483647;
            Console.WriteLine(" int 하한 : \"" + i1.ToString() + "\" int 상한 : \"" + i2.ToString()+ "\"" + "\n");
            // unsigned variable : 부호없음,0~자연수만 저장 가능
            byte bt = 0;
            byte bt2 = 255;
            ushort ush = 0;
            ushort ush2 = 65535;
            Console.WriteLine(" byte 하한 : \"" + bt.ToString() + "\" byte 상한 : \"" + bt2.ToString() + "\"" + "\n");
            Console.WriteLine(" ushort 하한 : \"" + ush.ToString() + "\" ushort 상한 : \"" + ush2.ToString() + "\"" + "\n");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasicForCad10
{
    class Program
    {
        // OOP Intro / Inheritance / Polymorphism
        static void Main(string[] args)
        {

            //Person person1 = new Person();
            //Person person1 = new Person("kim", "k", 22);
            //person1.DisplayPersonInfo();
            //Person person = new Person();
            //person.FirstName = "ddddddddddddddddddddddddddddddddddddddddddddddddddddd";
            //person.LastName = "hs";
            //person.Age = 25;

            //Console.WriteLine("first name is {0}", person.FirstName);
            //Console.WriteLine("last name is {0}", person.LastName);
            //Console.WriteLine("age is {0}", person.Age);
            //person.DisplayPersonInfo();
            //person.DoWork();

/*
            실행결과
            first name is DefaultFirstName  : 문자열이 길어서 입력 안됨 (setter에서 if 절 적용)
            last name is hs 
            age is 25 
                내부 변수만 출력
            full name : DefaultFirstName DefaultlastName and age : 20
            first name : DefaultFirstName / last name: DefaultlastName and age: 20
                public으로 변경 불가 ( _firstname) , public으로 변경 불가 ( _lastname), public으로 변경 불가 (_Age)

*/

            Doctor doc1 = new Doctor("kim", "dan", 35, "Oncology");
            
            Console.WriteLine("\n I am a Doctor and my specialty is {0}", doc1.Specialty);
            // 상속받은 Method 사용
            doc1.DoWork();
            
            doc1.DisplayPersonInfo();
            string work = doc1.DoWork(5);
            Console.WriteLine(work);

            Engineer engineer1 = new Engineer();
            engineer1.FirstName = "jim";
            engineer1.LastName = "hc";
            engineer1.Age = 32;
            engineer1.Degree = "Piping";
            Console.WriteLine("\n I am a Engineer and my degree is {0}", engineer1.Degree);

            engineer1.DoWork();
            engineer1.DisplayPersonInfo();

            Console.ReadLine();
        }
    }
}


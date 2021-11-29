using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasicForCad03
{
    //class 익히기
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.FirstName = "K";
            person.LastName = "SS";
            person.Age = 25;

            Person p2 = new Person("Lee", "dadd", 22);

            string infomation = person.DisplayPersonInfo();
            string info2 = p2.DisplayPersonInfo();
            Console.WriteLine(infomation);
            Console.WriteLine(info2);
        }


    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person() { } //without construct
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string DisplayPersonInfo()
        {
            string FullInformation = "Full name is :" + FirstName + " " + LastName + " and your age is : " + Age.ToString();
            return FullInformation;
        }
    }
}

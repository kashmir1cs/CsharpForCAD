using System;


namespace CsharpBasicForCad10
{
    // Inheritance
    class Doctor :Person 
    {
        // Doctor class는 Person을 상속함
        public string Specialty { get; set; }
        public Doctor() { }
        
        public Doctor(string firstName, string lastName, int age, string specialty)
        {
            // FirstName/ LastName은 Person Class의 First/Last Name 속성 상속
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty; //Doctor class
        }
        // override the method
        public string DoWork()
        {
            // Do some specific work here for the Doctor
            DoworkPrivately();
            return "";
        }

        private void DoworkPrivately()
        {
            Console.WriteLine("I prescribe medication");
            Console.WriteLine("I perform surgery");

        }
        // overload
        public string DoWork(int noOfTimes)
        {
            for (int i =1;i<=noOfTimes;i++)
            {
                Console.WriteLine("\n I perform operation {0} times a day", i);
            }
            return "And I'm tired";
        }
    }
}

출처: https://gunding.tistory.com/86 [[답내만]답답해서 내가 만든 IT 자료]

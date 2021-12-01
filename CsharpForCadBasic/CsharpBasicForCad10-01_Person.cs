using System;

 

namespace CsharpBasicForCad10
{
    class Person
    {
        // declare field (private)
        private string _firstname = "DefaultFirstName";
        private string _lastname = "DefaultlastName";
        private int _age = 20;

        // declare the properties (public properties)
        public string FirstName
        {
            get
            {
                return _firstname;
            }

            set
            {
                if(value.Length <=20 && value!= null)
                {
                    _firstname = value;
                }
            }

        }
        public string LastName 
        { 
            get { return _lastname; }
            set { _lastname= value;}
        }
        public int Age 
        { 
            get { return _age; }

            set { _age = value; }
        }
        public string DoWork()
        {
            // do some other work here
            DoWorkPrivately();
            return "I do general labour work";
        }

        private void DoWorkPrivately()
        {
            Console.WriteLine("I do gardening");
            Console.WriteLine("I clean house");
            Console.WriteLine("I walk the dog");
        }


        public Person() { } // constructor

        public Person(string firstName, string lastName, int age)
        {
            _firstname = firstName;
            _lastname = lastName;
            _age = age;

            
        }
        public void DisplayPersonInfo()
        {
            Console.WriteLine("full name : {0} {1} and age : {2}", _firstname, _lastname, _age.ToString());
            Console.WriteLine("first name : {0} / last name : {1} and age : {2}", _firstname, _lastname, _age.ToString());
            
        }
    }
}


좋아요공감
공유하기통계글 요소
저작자표시


출처: https://gunding.tistory.com/85 [[답내만]답답해서 내가 만든 IT 자료]

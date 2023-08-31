using System;

namespace DefiningPersonClassWithCustomMethod
{
    // Exercise: Methods Task #1

    public class Person
    {
        private string name;

        private int age;

        public Person()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public void IntroduceYourself()
        {
            Console.WriteLine($"Здравейте, аз съм {Name} и съм на {Age} години.");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            firstPerson.Name = "Гошо";
            firstPerson.Age = 15;

            firstPerson.IntroduceYourself();
        }
    }
}

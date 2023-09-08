using System;

namespace PersonClassDefinition
{
    public class Person
    {
        private string name;

        private int age;

        private static int counter;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            counter += 1;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public static int Counter
        {
            get
            {
                return counter;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Ivan", 17);
            Console.WriteLine(Person.Counter);
        }
    }
}

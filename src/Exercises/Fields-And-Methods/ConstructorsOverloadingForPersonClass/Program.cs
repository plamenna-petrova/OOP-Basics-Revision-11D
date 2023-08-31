using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConstructorsOverloadingForPersonClass
{
    // Exercise: Constructors Task #2

    public class Person
    {
        private string name;

        private int age;

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int age)
            : this()
        {
            this.age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.name = name;
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
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            ConstructorInfo emptyConstructorInfo = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageConstructorInfo = personType.GetConstructor(new[] { typeof(int) });
            ConstructorInfo nameAndAgeConstructorInfo = personType.GetConstructor(new[] { typeof(string), typeof(int) });

            bool areNameAndAgeConstructorParametersSwapped = false;

            if (nameAndAgeConstructorInfo == null)
            {
                nameAndAgeConstructorInfo = personType.GetConstructor(new[] { typeof(int), typeof(string) });
                areNameAndAgeConstructorParametersSwapped = true;
            }

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person basePerson = (Person)emptyConstructorInfo.Invoke(new object[] { });
            Person personWithAge = (Person)ageConstructorInfo.Invoke(new object[] { age });
            Person personWithNameAndAge = areNameAndAgeConstructorParametersSwapped
                ? (Person)nameAndAgeConstructorInfo.Invoke(new object[] { age, name })
                : (Person)nameAndAgeConstructorInfo.Invoke(new object[] { name, age });

            Console.WriteLine("{0} {1}", basePerson.Name, basePerson.Age);
            Console.WriteLine("{0} {1}", personWithAge.Name, personWithAge.Age);
            Console.WriteLine("{0} {1}", personWithNameAndAge.Name, personWithNameAndAge.Age);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticsResearch
{
    // Exercise: Fields And Properties Task #5

    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }

    public class People
    {
        private List<Person> peopleForStatistics = new List<Person>();

        public List<Person> PeopleForStatistics
        {
            get { return peopleForStatistics; }
            set { peopleForStatistics = value; }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            People people = new People();

            while (numberOfPeople > 0)
            {
                string[] peopleForStatisticsInfo = Console.ReadLine().Split(' ').ToArray();
                string name = peopleForStatisticsInfo[0];
                int age = int.Parse(peopleForStatisticsInfo[1]);

                Person person = new Person(name, age);
                people.PeopleForStatistics.Add(person);

                numberOfPeople--;
            }

            List<Person> peopleOverThirty = people.PeopleForStatistics
                    .Where(p => p.Age > 30)
                    .OrderBy(p => p.Name)
                    .ToList();

            foreach (var person in peopleOverThirty)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}

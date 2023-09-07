using System;
using System.Collections.Generic;

namespace FirstAndReserveTeam
{
    // Exercise: Additional Problems Part 1 Task #1

    public class Team
    {
        private string name;

        private List<Person> firstTeam;

        private List<Person> reserveTeam;

        public Team()
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public Team(string name) : this()
        {
            this.name = name;
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            } 
            else
            {
                reserveTeam.Add(person);
            }
        }
    }

    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        private double salary;

        public Person(string firstName, string lastName, int age, double salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                this.age = value;
            }
        }

        public double Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                this.salary = value;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeamMembers = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfTeamMembers; i++)
            {
                string[] personDetails = Console.ReadLine().Split();
                string personFirstName = personDetails[0];
                string personLastName = personDetails[1];
                int personAge = int.Parse(personDetails[2]);
                double personSalary = double.Parse(personDetails[3]);

                Person person = new Person(personFirstName, personLastName, personAge, personSalary);
                people.Add(person);
            }

            Team team = new Team();

            foreach (var person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team have {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
        }
    }
}

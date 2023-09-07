using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    // Exercise: Additional Problems Task #5

    public class Person
    {
        private string name;

        private Company company;

        private Car car;

        private List<Parent> parents = new List<Parent>();

        private List<Child> children = new List<Child>();

        private List<Pokemon> pokemons = new List<Pokemon>();
 
        public Person()
        {
            
        }

        public Person(string name) : this()
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Child> Children
        {
            get { return children; }
            set { children = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }
    }

    public class Company
    {
        private string name;

        private string department;

        private double salary;

        public Company()
        {

        }

        public Company(string name, string department, double salary) : this()
        {
            this.name = name;
            this.department = department;
            this.salary = salary;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public override string ToString()
        {
            return $"{Name} {Department} {Salary:F2}";
        }
    }

    public class Car
    {
        private string model;

        private int speed;

        public Car()
        {
            
        }

        public Car(string model, int speed) : this()
        {
            this.model = model;
            this.speed = speed;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public override string ToString()
        {
            return $"{Model} {Speed}";
        }
    }

    public class Parent
    {
        private string name;

        private string birthDate;

        public Parent()
        {
            
        }

        public Parent(string name, string birthDate) : this()
        {
            this.name = name;
            BirthDate = birthDate;

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public override string ToString()
        {
            return $"{Name} {BirthDate}";
        }
    }

    public class Child
    {
        private string name;

        private string birthDate;

        public Child()
        {
            
        }

        public Child(string name, string birthDate) : this()
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public override string ToString()
        {
            return $"{Name} {BirthDate}";
        }
    }

    public class Pokemon
    {
        private string name;

        private string element;

        public Pokemon(string name, string element)
        {
            this.name = name;
            this.element = element;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Element
        { 
            get { return element; }
            set { element = value; }
        }

        public override string ToString()
        {
            return $"{Name} {Element}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            bool isPersonCommandsSendingActive = true;

            List<Person> people = new List<Person>();

            while (isPersonCommandsSendingActive)
            {
                string[] personCommands = Console.ReadLine().Split().ToArray();

                if (personCommands[0] == "End")
                {
                    isPersonCommandsSendingActive = false;
                    break;
                }

                string personName = personCommands[0];

                if (!people.Any(p => p.Name == personName))
                {
                    people.Add(new Person(personName));
                }

                Person person = people.Where(p => p.Name == personName).FirstOrDefault();

                string personInformationIdentifier = personCommands[1];

                switch (personInformationIdentifier)
                {
                    case "company":
                        string companyName = personCommands[2];
                        string companyDepartment = personCommands[3];
                        double salaryInCompany = double.Parse(personCommands[4]);
                        
                        if (person.Company == null)
                        {
                            person.Company = new Company(companyName, companyDepartment, salaryInCompany);
                        }
                        else
                        {
                            if (person.Company.Name != companyName)
                            {
                                person.Company.Name = companyName;
                                person.Company.Department = companyDepartment;
                                person.Company.Salary = salaryInCompany;
                            }
                        }
                        break;
                    case "pokemon":
                        string pokemonName = personCommands[2];
                        string pokemonElement = personCommands[3];
                        if (!person.Pokemons.Any(p => p.Name == pokemonName && p.Element == pokemonElement))
                        {
                            person.Pokemons.Add(new Pokemon(pokemonName, pokemonElement));  
                        }
                        break;
                    case "parents":
                        string parentName = personCommands[2];
                        string parentBirthDate = personCommands[3];
                        if (!person.Parents.Any(p => p.Name == parentName && p.BirthDate == parentBirthDate))
                        {
                            person.Parents.Add(new Parent(parentName, parentBirthDate));
                        }
                        break;
                    case "children":
                        string childName = personCommands[2];
                        string childBirthDate = personCommands[3];
                        if (!person.Children.Any(c => c.Name == childName && c.BirthDate == childBirthDate))
                        {
                            person.Children.Add(new Child(childName, childBirthDate));
                        }
                        break;
                    case "car":
                        string carModel = personCommands[2];
                        int carSpeed = int.Parse(personCommands[3]);

                        if (person.Car == null)
                        {
                            person.Car = new Car(carModel, carSpeed);
                        }
                        else
                        {
                            if (person.Car.Model != carModel)
                            {
                                person.Car.Model = carModel;
                                person.Car.Speed = carSpeed;
                            }
                        }
                        break;
                }
            }

            if (!isPersonCommandsSendingActive)
            {
                string personNameToFind = Console.ReadLine();
                Person personToFind = people.Where(p => p.Name == personNameToFind).FirstOrDefault();

                if (personToFind != null)
                {
                    Console.WriteLine(personToFind.Name);

                    Console.WriteLine("Company:");

                    if (personToFind.Company != null)
                    {
                        Console.WriteLine(personToFind.Company.ToString());
                    }

                    Console.WriteLine("Car:");

                    if (personToFind.Car != null)
                    {
                        Console.WriteLine(personToFind.Car.ToString());
                    }

                    Console.WriteLine("Pokemon:");

                    if (personToFind.Pokemons.Any())
                    {
                        foreach (Pokemon pokemon in personToFind.Pokemons)
                        {
                            Console.WriteLine(pokemon.ToString());
                        }
                    }

                    Console.WriteLine("Parents:");

                    if (personToFind.Parents.Any())
                    {
                        foreach (Parent parent in personToFind.Parents)
                        {
                            Console.WriteLine(parent.ToString());
                        }
                    }

                    Console.WriteLine("Children:");

                    if (personToFind.Children.Any())
                    {
                        foreach (Child child in personToFind.Children)
                        {
                            Console.WriteLine(child.ToString());
                        }
                    }
                }
            }
        }
    }
}

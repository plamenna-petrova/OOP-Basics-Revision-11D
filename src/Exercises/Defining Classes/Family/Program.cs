using System;
using System.Collections.Generic;
using System.Linq;

namespace Family
{
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
    }

    public class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();
    }

    public class Program
    {
        static void PrintFamilyMembersInfo(Family family)
        {
            List<Person> orderedFamilyMembersByName = family.FamilyMembers.OrderBy(fm => fm.Name).ToList();

            foreach (Person familyMember in orderedFamilyMembersByName)
            {
                Console.WriteLine($"{familyMember.Name} {familyMember.Age}");
            }
        }

        static void Main(string[] args)
        {
            int familyMembersCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            while (familyMembersCount > 0)
            {
                string[] familyMemberInfo = Console.ReadLine().Split(' ').ToArray();
                string familyMemberName = familyMemberInfo[0];
                int familyMemberAge = int.Parse(familyMemberInfo[1]);

                Person newFamilyMember = new Person(familyMemberName, familyMemberAge);
                family.FamilyMembers.Add(newFamilyMember);

                familyMembersCount--;
            }

            PrintFamilyMembersInfo(family);
        }
    }
}

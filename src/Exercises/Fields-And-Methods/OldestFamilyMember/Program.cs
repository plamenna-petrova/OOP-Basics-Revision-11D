using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OldestFamilyMember
{
    // Exercise: Fields And Properties Task #4

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
            return $"{Name} {Age}"; 
        }
    }

    public class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();

        public void AddMember(Person familyMember)
        {
            FamilyMembers.Add(familyMember);
        }

        public Person GetOldestMember()
        {
            return FamilyMembers.OrderByDescending(x => x.Age).First();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");

            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

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

            Person oldestFamilyMember = family.GetOldestMember();
            Console.WriteLine(oldestFamilyMember.ToString());
        }
    }
}

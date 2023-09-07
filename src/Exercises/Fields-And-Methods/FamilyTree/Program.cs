using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTree
{
    // Exercise: Additional Problems Task #6

    public class Person
    {
        private string firstName;

        private string lastName;

        private string birthDate;

        private List<Person> parents = new List<Person>();

        private List<Person> children = new List<Person>(); 

        public Person()
        {

        }

        public Person(string firstName, string lastName, string birthDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public List<Person> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Person> Children
        {
            get { return children; }
            set { children = value; }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {BirthDate}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleInFamilyTree = new List<Person>();

            bool isFamilyTreeComandsSendingActive = true;

            while (isFamilyTreeComandsSendingActive)
            {
                string familyTreeCommandString = Console.ReadLine();

                if (familyTreeCommandString == "End")
                {
                    isFamilyTreeComandsSendingActive = false;
                    break;
                }

                if (familyTreeCommandString.Contains("-"))
                {
                    string[] splittedFamilyTreeCommandString = familyTreeCommandString.Split('-').ToArray();
                    string familyTreeCommandFirstPart = splittedFamilyTreeCommandString[0].Trim();
                    string familyTreeCommandSecondPart = splittedFamilyTreeCommandString[1].Trim();

                    if (familyTreeCommandFirstPart.Contains("/"))
                    {
                        Person parent = peopleInFamilyTree
                            .Where(p => p.BirthDate == familyTreeCommandFirstPart)
                            .FirstOrDefault();

                        if (parent == null)
                        {
                            parent = new Person
                            {
                                BirthDate = familyTreeCommandFirstPart
                            };

                            peopleInFamilyTree.Add(parent);

                            if (familyTreeCommandSecondPart.Contains("/"))
                            {
                                Person personWithBirthdate = peopleInFamilyTree
                                    .Where(p => p.BirthDate == familyTreeCommandSecondPart)
                                    .FirstOrDefault();

                                if (personWithBirthdate == null)
                                {
                                    personWithBirthdate = new Person
                                    {
                                        BirthDate = familyTreeCommandSecondPart
                                    };

                                    peopleInFamilyTree.Add(personWithBirthdate);
                                    personWithBirthdate.Parents.Add(parent);
                                    parent.Children.Add(personWithBirthdate);
                                }
                                else
                                {
                                    personWithBirthdate.Parents.Add(parent);
                                    parent.Children.Add(personWithBirthdate);
                                }
                            }
                            else
                            {
                                string[] personDetails = familyTreeCommandSecondPart.Split().ToArray();
                                string personFirstName = personDetails[0];
                                string personLastName = personDetails[1];
                                    
                                Person personWithNames = peopleInFamilyTree
                                    .Where(p => p.FirstName == personFirstName && p.LastName == personLastName)
                                    .FirstOrDefault();

                                if (personWithNames == null)
                                {
                                    personWithNames = new Person
                                    {
                                        FirstName = personFirstName,
                                        LastName = personLastName
                                    };

                                    peopleInFamilyTree.Add(personWithNames);
                                    personWithNames.Parents.Add(parent);
                                    parent.Children.Add(personWithNames);
                                }
                                else
                                {
                                    personWithNames.Parents.Add(parent);
                                    parent.Children.Add(personWithNames);
                                }
                            }
                        }
                        else
                        {
                            if (familyTreeCommandSecondPart.Contains("/"))
                            {
                                Person personWithBirthdate = peopleInFamilyTree
                                    .Where(p => p.BirthDate == familyTreeCommandSecondPart)
                                    .FirstOrDefault();

                                if (personWithBirthdate == null)
                                {
                                    personWithBirthdate = new Person
                                    {
                                        BirthDate = familyTreeCommandSecondPart
                                    };

                                    peopleInFamilyTree.Add(personWithBirthdate);
                                    personWithBirthdate.Parents.Add(parent);
                                    parent.Children.Add(personWithBirthdate);
                                }
                                else
                                {
                                    if (personWithBirthdate.Parents.Any(p => p.BirthDate == familyTreeCommandSecondPart))
                                    {
                                        if (!parent.Children.Any(c => c.BirthDate == familyTreeCommandSecondPart))
                                        {
                                            parent.Children.Add(personWithBirthdate);
                                        }
                                    }
                                    else
                                    {
                                        personWithBirthdate.Parents.Add(parent);
                                        parent.Children.Add(personWithBirthdate);
                                    }
                                }
                            }
                            else
                            {
                                string[] personDetails = familyTreeCommandSecondPart.Split().ToArray();
                                string personFirstName = personDetails[0];
                                string personLastName = personDetails[1];

                                Person personWithNames = peopleInFamilyTree
                                    .Where(p => p.FirstName == personFirstName && p.LastName == personLastName)
                                    .FirstOrDefault();

                                if (personWithNames == null)
                                {
                                    personWithNames = new Person
                                    {
                                        FirstName = personFirstName,
                                        LastName = personLastName
                                    };

                                    peopleInFamilyTree.Add(personWithNames);
                                    personWithNames.Parents.Add(parent);
                                    parent.Children.Add(personWithNames);
                                }
                                else
                                {
                                    if (personWithNames.Parents.Any(p => p.FirstName == personFirstName && 
                                        p.LastName == personLastName))
                                    {
                                        if (!parent.Children.Any(c => c.FirstName == personFirstName &&
                                            c.LastName == c.LastName))
                                        {
                                            parent.Children.Add(personWithNames);
                                        }
                                    }
                                    else
                                    {
                                        personWithNames.Parents.Add(parent);
                                        parent.Children.Add(personWithNames);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string[] personNames = familyTreeCommandFirstPart.Split().ToArray();
                        string personFirstName = personNames[0];
                        string personLastName = personNames[1];

                        Person parent = peopleInFamilyTree
                            .Where(p => p.FirstName == personFirstName && p.LastName == personLastName)
                            .FirstOrDefault();

                        if (parent == null)
                        {
                            parent = new Person
                            {
                                FirstName = personFirstName,
                                LastName = personLastName
                            };

                            peopleInFamilyTree.Add(parent);

                            if (familyTreeCommandSecondPart.Contains("/"))
                            {
                                Person personWithBirthdate = peopleInFamilyTree
                                    .Where(p => p.BirthDate == familyTreeCommandSecondPart)
                                    .FirstOrDefault();

                                if (personWithBirthdate == null)
                                {
                                    personWithBirthdate = new Person
                                    {
                                        BirthDate = familyTreeCommandSecondPart
                                    };

                                    peopleInFamilyTree.Add(personWithBirthdate);
                                    personWithBirthdate.Parents.Add(parent);
                                    parent.Children.Add(personWithBirthdate);
                                }
                                else
                                {
                                    personWithBirthdate.Parents.Add(parent);
                                    parent.Children.Add(personWithBirthdate);
                                }
                            }
                            else
                            {
                                string[] personDetails = familyTreeCommandSecondPart.Split().ToArray();

                                Person personWithNames = peopleInFamilyTree
                                    .Where(p => p.FirstName == personDetails[0] && p.LastName == personDetails[1])
                                    .FirstOrDefault();

                                if (personWithNames == null)
                                {
                                    personWithNames = new Person
                                    {
                                        FirstName = personDetails[0],
                                        LastName = personDetails[1]
                                    };

                                    peopleInFamilyTree.Add(personWithNames);
                                    personWithNames.Parents.Add(parent);
                                    parent.Children.Add(personWithNames);
                                }
                                else
                                {
                                    personWithNames.Parents.Add(parent);
                                    parent.Children.Add(personWithNames);
                                }
                            }
                        }
                        else
                        {
                            if (familyTreeCommandSecondPart.Contains("/"))
                            {
                                Person personWithBirthdate = peopleInFamilyTree
                                    .Where(p => p.BirthDate == familyTreeCommandSecondPart)
                                    .FirstOrDefault();

                                if (personWithBirthdate == null)
                                {
                                    personWithBirthdate = new Person
                                    {
                                        BirthDate = familyTreeCommandSecondPart
                                    };

                                    peopleInFamilyTree.Add(personWithBirthdate);
                                    personWithBirthdate.Parents.Add(parent);
                                    parent.Children.Add(personWithBirthdate);
                                }
                                else
                                {
                                    if (personWithBirthdate.Parents.Any(p => p.BirthDate == familyTreeCommandSecondPart))
                                    {
                                        if (!parent.Children.Any(c => c.BirthDate == familyTreeCommandSecondPart))
                                        {
                                            parent.Children.Add(personWithBirthdate);
                                        }
                                    }
                                    else
                                    {
                                        personWithBirthdate.Parents.Add(parent);
                                        parent.Children.Add(personWithBirthdate);
                                    }
                                }
                            }
                            else
                            {
                                string[] personDetails = familyTreeCommandSecondPart.Split().ToArray();

                                Person personWithNames = peopleInFamilyTree
                                    .Where(p => p.FirstName == personDetails[0] && p.LastName == personDetails[0])
                                    .FirstOrDefault();

                                if (personWithNames == null)
                                {
                                    personWithNames = new Person
                                    {
                                        FirstName = personDetails[0],
                                        LastName = personDetails[1]
                                    };

                                    peopleInFamilyTree.Add(personWithNames);
                                    personWithNames.Parents.Add(parent);
                                    parent.Children.Add(personWithNames);
                                }
                                else
                                {
                                    if (personWithNames.Parents.Any(p => p.FirstName == personFirstName &&
                                        p.LastName == personLastName))
                                    {
                                        if (!parent.Children.Any(c => c.FirstName == personFirstName &&
                                            c.LastName == c.LastName))
                                        {
                                            parent.Children.Add(personWithNames);
                                        }
                                    }
                                    else
                                    {
                                        personWithNames.Parents.Add(parent);
                                        parent.Children.Add(personWithNames);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    string[] personFullDetails = new string[3];
                    string[] personInput = familyTreeCommandString.Split().ToArray();
                    Array.Copy(personInput, personFullDetails, personInput.Length);

                    string personFirstName = null;
                    string personLastName = null;
                    string personBirthDate = null;

                    if (personFullDetails[0].Contains('/'))
                    {
                        personBirthDate = personFullDetails[0];
                    }
                    else
                    {
                        personFirstName = personFullDetails[0];
                        personLastName = personFullDetails[1];

                        if (personFullDetails[2] != null)
                        {
                            personBirthDate = personFullDetails[2];
                        }
                    }

                    Person person = new Person(personFirstName, personLastName, personBirthDate);

                    if (person.FirstName != null && person.LastName != null && person.BirthDate != null)
                    {
                        Person personWithNames = peopleInFamilyTree
                            .Where(p => p.FirstName == person.FirstName && p.LastName == p.LastName)
                            .FirstOrDefault();

                        Person personWithBirthDate = peopleInFamilyTree
                            .Where(p => p.BirthDate == person.BirthDate)
                            .FirstOrDefault();

                        if (personWithNames == null && personWithBirthDate == null)
                        {
                            peopleInFamilyTree.Add(person);
                        }
                        else
                        {
                            if (personWithNames != null)
                            {
                                personWithNames.BirthDate = person.BirthDate;
                            }

                            if (personWithBirthDate != null)
                            {
                                personWithBirthDate.FirstName = person.FirstName;
                                personWithBirthDate.LastName = person.LastName;
                            }
                        }
                    }
                    else
                    {
                        peopleInFamilyTree.Add(person);
                    }
                }
            }

            if (!isFamilyTreeComandsSendingActive)
            {
                Person firstNotedPersonInFamilyTree = peopleInFamilyTree[0];

                Person matchingPersonWithBirthDate = peopleInFamilyTree
                    .Skip(1)
                    .Where(p => p.BirthDate == firstNotedPersonInFamilyTree.BirthDate)    
                    .FirstOrDefault();

                if (matchingPersonWithBirthDate != null)
                {
                    firstNotedPersonInFamilyTree.Parents = firstNotedPersonInFamilyTree.Parents.Union(matchingPersonWithBirthDate.Parents).ToList();
                    firstNotedPersonInFamilyTree.Children = firstNotedPersonInFamilyTree.Children.Union(matchingPersonWithBirthDate.Children).ToList();
                    peopleInFamilyTree.Remove(matchingPersonWithBirthDate);
                }

                Person matchingPersonWithNames = peopleInFamilyTree
                    .Skip(1)
                    .Where(p => p.FirstName == firstNotedPersonInFamilyTree.FirstName && 
                                p.LastName == firstNotedPersonInFamilyTree.LastName)
                    .FirstOrDefault();

                if (matchingPersonWithNames != null)
                {
                    firstNotedPersonInFamilyTree.Parents = firstNotedPersonInFamilyTree.Parents.Union(matchingPersonWithNames.Parents).ToList();
                    firstNotedPersonInFamilyTree.Children = firstNotedPersonInFamilyTree.Children.Union(matchingPersonWithNames.Children).ToList();
                    peopleInFamilyTree.Remove(matchingPersonWithNames);
                }

                Console.WriteLine(firstNotedPersonInFamilyTree.ToString());

                Console.WriteLine("Parents:");

                if (firstNotedPersonInFamilyTree.Parents != null)
                {
                    foreach (Person parent in firstNotedPersonInFamilyTree.Parents)
                    {
                        Console.WriteLine(parent.ToString());
                    }
                }

                Console.WriteLine("Children:");

                if (firstNotedPersonInFamilyTree.Children != null)
                {
                    foreach (Person child in firstNotedPersonInFamilyTree.Children)
                    {
                        Console.WriteLine(child.ToString());
                    }
                }
            }
        }
    }
}

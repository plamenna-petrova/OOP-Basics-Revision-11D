using System;

namespace Creature
{
    // Exercise: Encapsulation this Task #1

    public class Creature
    {
        private string name;

        private int years;

        private string areal;

        public Creature()
        {

        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Years
        {
            get => this.years;
            set => this.years = value;
        }

        public string Areal
        {
            get
            {
                return this.areal;
            }
            set
            {
                this.areal = value;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

using System;
using System.Linq;
using System.Reflection;

namespace Box
{
    // Exercise: Encapsulation this Task #3

    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double CalculateSurfaceArea()
        {
            return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * this.length * this.height + 2 * this.width * this.height;
        }

        public double CalculateVolume()
        {
            return this.length * this.width * this.height;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            double boxLength = double.Parse(Console.ReadLine());
            double boxWidth = double.Parse(Console.ReadLine());
            double boxHeight = double.Parse(Console.ReadLine());

            Box box = new Box(boxLength, boxWidth, boxHeight);

            Type boxType = typeof(Box);

            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine(fields.Count());
            Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.CalculateVolume():F2}");
        }
    }
}

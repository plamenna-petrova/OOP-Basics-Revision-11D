using System;
using System.Collections.Generic;
using System.Linq;

namespace RectanglesOverlapping
{
    // Exercise: Additional Problems Task #2

    public class Rectangle
    {
        private string id;

        private int width;

        private int height;

        private int[] upperLeftCornerCoordinates = new int[2];

        public Rectangle()
        {

        }

        public Rectangle(string id, int width, int height, int[] upperLeftCornerCoordinates) : this()
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.upperLeftCornerCoordinates = upperLeftCornerCoordinates;
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int[] UpperLeftCornerCoordinates
        {
            get { return upperLeftCornerCoordinates; }
            set { upperLeftCornerCoordinates = value; }
        }
    }

    public class Program
    {
        static bool AreRectangleOverlapping(Rectangle firstRectange, Rectangle secondRectangle)
        {
            if (firstRectange.UpperLeftCornerCoordinates[0] == secondRectangle.UpperLeftCornerCoordinates[0] &&
                firstRectange.UpperLeftCornerCoordinates[1] == secondRectangle.UpperLeftCornerCoordinates[1])
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            int[] rectanglesOperationsDetails = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberOfRectangles = rectanglesOperationsDetails[0];
            int numberOfRectanglesOverlappingChecks = rectanglesOperationsDetails[1];

            List<Rectangle> rectangles = new List<Rectangle>();

            while (numberOfRectangles > 0)
            {
                string[] rectanglesInfo = Console.ReadLine().Split().ToArray();

                Rectangle rectangle = new Rectangle(
                    rectanglesInfo[0],
                    int.Parse(rectanglesInfo[1]),
                    int.Parse(rectanglesInfo[2]),
                    new int[] { int.Parse(rectanglesInfo[3]), int.Parse(rectanglesInfo[4]) }
                );

                rectangles.Add(rectangle);

                numberOfRectangles--;
            }

            while (numberOfRectanglesOverlappingChecks > 0)
            {
                string[] rectanglesIDs = Console.ReadLine().Split().ToArray();
                string firstRectangleID = rectanglesIDs[0];
                string secondRectangleID = rectanglesIDs[1];

                Rectangle firstRectangleToCheckForOverlapping = rectangles.Where(r => r.ID == firstRectangleID).First();
                Rectangle secondRectangleToCheckForOverlapping = rectangles.Where(r => r.ID == secondRectangleID).First();

                bool areRectanglesOverlapping = AreRectangleOverlapping(
                    firstRectangleToCheckForOverlapping, secondRectangleToCheckForOverlapping
                );

                Console.WriteLine(areRectanglesOverlapping.ToString().ToLower());

                numberOfRectanglesOverlappingChecks--;
            }
        }
    }
}

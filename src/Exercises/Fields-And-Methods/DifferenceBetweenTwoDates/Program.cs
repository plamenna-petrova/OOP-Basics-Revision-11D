using System;
using System.Linq;

namespace DifferenceBetweenTwoDates
{
    // Exercise: Fields And Properties Task #6

    public class DateModifier
    {
        public int GetDatesDifference(string firstDateString, string secondDateString)
        {
            int[] firstDateArray = firstDateString.Split().Select(int.Parse).ToArray();
            int[] secondDateArray = secondDateString.Split().Select(int.Parse).ToArray();

            DateTime firstDate = new DateTime(firstDateArray[0], firstDateArray[1], firstDateArray[2]);
            DateTime secondDate = new DateTime(secondDateArray[0], secondDateArray[1], secondDateArray[2]);

            int datesDifference = (firstDate.Date - secondDate.Date).Days;

            return Math.Abs(datesDifference);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string firstDateDetails = Console.ReadLine();
            string secondDateDetails = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            Console.WriteLine(dateModifier.GetDatesDifference(firstDateDetails, secondDateDetails));
        }
    }
}

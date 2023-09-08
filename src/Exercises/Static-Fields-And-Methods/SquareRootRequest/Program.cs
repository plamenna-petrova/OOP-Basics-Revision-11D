using System;

namespace SquareRootRequest
{
    public static class SquareRootRequestManager
    {
        public static void CalculateSquareRoot(int number)
        {
            Console.WriteLine(Math.Sqrt(number));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int numberToCalculateSquareRoot = int.Parse(Console.ReadLine());
                SquareRootRequestManager.CalculateSquareRoot(numberToCalculateSquareRoot);
            }
        }
    }
}

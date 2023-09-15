using GrandPrix.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandPrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfLapsInRace = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());

            RaceTower raceTower = new RaceTower();
            raceTower.SetTrackInfo(numberOfLapsInRace, trackLength);

            while (true)
            {
                List<string> raceCommand = Console.ReadLine().Split().ToList();

                switch (raceCommand[0])
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(raceCommand.Skip(1).ToList());
                        break;
                    case "CompleteLaps":
                        raceTower.CompleteLaps(raceCommand.Skip(1).ToList());
                        break;
                }
            }
        }
    }
}

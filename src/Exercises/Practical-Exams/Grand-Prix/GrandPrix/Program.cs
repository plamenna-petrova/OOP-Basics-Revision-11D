using GrandPrix.Controllers;
using GrandPrix.Models.Drivers;
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

            bool isRacingCommandsSendingActive = true;

            while (isRacingCommandsSendingActive)
            {
                List<string> racingCommand = Console.ReadLine().Split().ToList();
                List<string> racingCommandArguments = racingCommand.Skip(1).ToList();

                switch (racingCommand[0])
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(racingCommandArguments);
                        break;
                    case "CompleteLaps":
                        string completedLapsInfo = raceTower.CompleteLaps(racingCommandArguments);
                        Console.WriteLine(completedLapsInfo);

                        if (raceTower.CompletedLaps == raceTower.Track.LapsNumber)
                        {
                            isRacingCommandsSendingActive = false;
                        }
                        break;
                    case "Leaderboard":
                        string leaderBoardInfo = raceTower.GetLeaderboard();
                        Console.WriteLine(leaderBoardInfo);
                        break;
                    case "Box":
                        raceTower.DriverBoxes(racingCommandArguments);
                        break;
                    case "ChangeWeather":
                        raceTower.DriverBoxes(racingCommandArguments);
                        break;
                }
            }

            if (!isRacingCommandsSendingActive)
            {
                Driver winnerInRace = raceTower.Drivers
                    .OrderByDescending(d => d.TotalTime)
                    .First();

                Console.WriteLine($"{winnerInRace.Name} wins the race for {Math.Round(winnerInRace.TotalTime, 3):F3} seconds.");
            }
        }
    }
}

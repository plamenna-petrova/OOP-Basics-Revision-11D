using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatingAFootballTeam
{
    // Exercise: Additional Problems Part 1 Task #2

    public class Team
    {
        private string name;

        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return Math.Round(this.players.Average(p => p.AverageStatistics));
            }
        }

        public List<Player> Players
        {
            get
            {
                return this.players;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }
    }

    public class Player
    {
        private string name;

        private Stats stats;

        public Player()
        {

        }

        public Player(string name, Stats stats)
        {
            this.name = name;
            this.stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty");
                }

                this.name = value;
            }
        }

        public double AverageStatistics
        {
            get
            {
                double totalStatistics = this.stats.Endurance +
                                         this.stats.Sprint +
                                         this.stats.Dribble +
                                         this.stats.Passes +
                                         this.stats.Shooting;

                double averageStatistics = totalStatistics / 5;

                return Math.Round(averageStatistics);
            }
        }
    }

    public class Stats
    {
        private const int MinStatisticsEntryValue = 0;

        private const int MaxStatisticsEntryValue = 100;

        private int endurance;

        private int sprint;

        private int dribble;

        private int passes;

        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passes, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passes = passes;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get 
            { 
                return this.endurance; 
            }

            set
            {
                if (endurance < MinStatisticsEntryValue || endurance > MaxStatisticsEntryValue)
                {
                    throw new ArgumentException($"Endurance should be between {MinStatisticsEntryValue} and {MaxStatisticsEntryValue}.");
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get 
            { 
                return this.sprint; 
            }

            set
            {
                if (sprint < MinStatisticsEntryValue || sprint > MaxStatisticsEntryValue)
                {
                    throw new ArgumentException($"Sprint should be between {MinStatisticsEntryValue} and {MaxStatisticsEntryValue}.");
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get 
            { 
                return this.dribble; 
            }

            set
            {
                if (dribble < MinStatisticsEntryValue || dribble > MaxStatisticsEntryValue)
                {
                    throw new ArgumentException($"Dribble should be between {MinStatisticsEntryValue} and {MaxStatisticsEntryValue}.");
                }

                this.dribble = value;
            }
        }

        public int Passes
        {
            get 
            { 
                return this.passes; 
            }

            set
            {
                if (passes < MinStatisticsEntryValue || passes > MaxStatisticsEntryValue)
                {
                    throw new ArgumentException($"Passes should be between {MinStatisticsEntryValue} and {MaxStatisticsEntryValue}.");
                }

                this.passes = value;
            }
        }

        public int Shooting
        {
            get 
            { 
                return this.shooting; 
            }

            set
            {
                if (shooting < MinStatisticsEntryValue || shooting > MaxStatisticsEntryValue)
                {
                    throw new ArgumentException($"Shooting should be between {MinStatisticsEntryValue} and {MaxStatisticsEntryValue}.");
                }

                this.shooting = value;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            bool isTeamCommandsSendingActive = true;

            List<Team> teams = new List<Team>();

            while (isTeamCommandsSendingActive)
            {
                string[] teamCommands = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                switch (teamCommands[0])
                {
                    case "Team":
                        string teamName = teamCommands[1];
                        Team team = new Team(teamName);
                        teams.Add(team);
                        break;
                    case "Add":
                        string teamToAddPlayerName = teamCommands[1];
                        Team teamToAddPlayer = teams.Where(t => t.Name == teamToAddPlayerName).FirstOrDefault();
                        
                        if (teamToAddPlayer == null)
                        {
                            Console.WriteLine($"Team {teamToAddPlayerName} does not exists.");
                        }
                        else
                        {
                            string playerName = teamCommands[2];
                            int playerEndurance = int.Parse(teamCommands[3]);
                            int playerSprint = int.Parse(teamCommands[4]);
                            int playerDribble = int.Parse(teamCommands[5]);
                            int playerPasses = int.Parse(teamCommands[6]);
                            int playerShooting = int.Parse(teamCommands[7]);
                            Stats playerStats = new Stats(playerEndurance, playerSprint, playerDribble, playerPasses, playerShooting);
                            Player player = new Player(playerName, playerStats);
                            teamToAddPlayer.AddPlayer(player);
                        }
                        break;
                    case "Remove":
                        string teamToRemovePlayerName = teamCommands[1];
                        Team teamToRemovePlayer = teams.Where(t => t.Name == teamToRemovePlayerName).FirstOrDefault();

                        if (teamToRemovePlayer == null)
                        {
                            Console.WriteLine($"Team {teamToRemovePlayerName} does not exists.");
                        }
                        else
                        {
                            string playerName = teamCommands[2];
                            Player playerToRemove = teamToRemovePlayer.Players.Where(p => p.Name == playerName).FirstOrDefault();

                            if (playerToRemove == null)
                            {
                                Console.WriteLine($"Player {playerName} is not in the {teamToRemovePlayerName} team.");
                            }
                            else
                            {
                                teamToRemovePlayer.RemovePlayer(playerToRemove);
                            }
                        }
                        break;
                    case "Rating":
                        string teamToShowStatsName = teamCommands[1];
                        Team teamToShowStats = teams.Where(t => t.Name == teamToShowStatsName).FirstOrDefault();

                        if (teamToShowStats == null)
                        {
                            Console.WriteLine($"Team {teamToShowStatsName} does not exists.");
                        }
                        else
                        {
                            Console.WriteLine($"{teamToShowStats.Name} - {teamToShowStats.Rating}");
                        }
                        break;
                    case "END":
                        isTeamCommandsSendingActive = false;
                        break;
                }
            }
        }
    }
}

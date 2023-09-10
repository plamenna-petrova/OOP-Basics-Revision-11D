using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWars
{
    public class Planet
    {
        private string name;

        private int metal;

        private int mineral;

        private List<Building> buildings;

        private List<Ship> ships;

        public Planet(string name, int metal, int mineral)
        {
            this.Name = name;
            this.Metal = metal;
            this.Mineral = mineral;
            this.Buildings = new List<Building>();
            this.Ships = new List<Ship>();
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
                    throw new ArgumentNullException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Metal
        {
            get
            {
                return this.metal;
            }

            set
            {
                this.metal = value;
            }
        }

        public int Mineral
        {
            get
            {
                return this.mineral;
            }

            set
            {
                this.mineral = value;
            }
        }

        public List<Building> Buildings
        {
            get
            {
                return this.buildings;
            }

            set
            {
                this.buildings = value;
            }
        }

        public List<Ship> Ships
        {
            get
            {
                return this.ships;
            }

            set
            {
                this.ships = value;
            }
        }

        public void ConstructBuilding(Building buildingToConstruct)
        {
            bool hasEnoughMetalForConstruction = Metal >= buildingToConstruct.Metal;
            bool hasEnoughMineralForConstruction = Mineral >= buildingToConstruct.Mineral;

            if (!hasEnoughMetalForConstruction && !hasEnoughMineralForConstruction) 
            {
                Console.WriteLine($"{Name} have not resource {nameof(Metal)} to build {buildingToConstruct.Name}");
            }
            else if (!hasEnoughMetalForConstruction)
            {
                Console.WriteLine($"{nameof(Metal)} on {Name} not enough to build a {buildingToConstruct.Name}");
            }
            else if (!hasEnoughMineralForConstruction)
            {
                Console.WriteLine($"{nameof(Mineral)} on {Name} not enough to build a {buildingToConstruct.Name}");
            }
            else
            {
                Metal -= buildingToConstruct.Metal;
                Mineral -= buildingToConstruct.Mineral;
                this.Buildings.Add(buildingToConstruct);
                Console.WriteLine($"On {Name} was builded {buildingToConstruct.Name}");
            }
        }

        public void ConstructShip(Ship shipToConstruct, int units)
        {
            bool hasEnoughMetalForConstruction = Metal >= shipToConstruct.Metal * units;
            bool hasEnoughMineralForConstruction = Mineral >= shipToConstruct.Mineral * units;

            if (!hasEnoughMetalForConstruction || !hasEnoughMineralForConstruction)
            {
                Console.WriteLine($"On {Name} can not to build a {shipToConstruct.Name} {units} units");
            }
            else
            {
                Metal -= shipToConstruct.Metal * units;
                Mineral -= shipToConstruct.Mineral * units;

                for (int i = 0; i < units; i++)
                {
                    this.Ships.Add(shipToConstruct);
                }

                Console.WriteLine($"On {Name} was builded {shipToConstruct.Name}");
            }
        }
    }

    public class Building
    {
        private string name;

        private int metal;

        private int mineral;

        public Building(string name, int metal, int mineral)
        {
            this.Name = name;
            this.Metal = metal;
            this.Mineral = mineral;
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
                    throw new ArgumentNullException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Metal
        {
            get
            {
                return this.metal;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative");
                }

                this.metal = value;
            }
        }

        public int Mineral
        {
            get
            {
                return this.mineral;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative");
                }

                this.mineral = value;
            }
        }
    }

    public class Ship
    {
        private string name;

        private int metal;

        private int mineral;

        public Ship(string name, int metal, int mineral)
        {
            this.Name = name;
            this.Metal = metal;
            this.Mineral = mineral;
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
                    throw new ArgumentNullException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Metal
        {
            get
            {
                return this.metal;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative");
                }

                this.metal = value;
            }
        }

        public int Mineral
        {
            get
            {
                return this.mineral;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative");
                }

                this.mineral = value;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            const string MetalMine = "MetalMine";
            const string MineralMine = "MineralMine";
            const string YardShip = "YardShip";

            const string Transporter = "Transporter";
            const string BattleShip = "BattleShip";
            const string Fighter = "Fighter";

            string[] planetsCommands = Console.ReadLine().Split();

            List<Planet> planets = new List<Planet>(); 

            for (int i = 0; i < planetsCommands.Length; i += 3)
            {
                string planetName = planetsCommands[i];
                int planetMetalDeposit = int.Parse(planetsCommands[i + 1]);
                int planetMineralDeposit = int.Parse(planetsCommands[i + 2]);
                Planet planet = new Planet(planetName, planetMetalDeposit, planetMineralDeposit);
                planets.Add(planet);
            }

            string[] buildingsCommands = Console.ReadLine().Split();

            List<Building> buildings = new List<Building>();

            for (int i = 0; i < buildingsCommands.Length; i += 3)
            {
                string buildingName = buildingsCommands[i];
                int buildingMetalDeposit = int.Parse(buildingsCommands[i + 1]);
                int buildingMineralDeposit = int.Parse(buildingsCommands[i + 2]);
                Building building = new Building(buildingName, buildingMetalDeposit, buildingMineralDeposit);
                buildings.Add(building);
            }

            string[] shipsCommands = Console.ReadLine().Split();

            List<Ship> ships = new List<Ship>();

            for (int i = 0; i < shipsCommands.Length; i += 3)
            {
                string shipName = shipsCommands[i];
                int shipMetalDeposit = int.Parse(shipsCommands[i + 1]);
                int shipMineralDeposit = int.Parse(shipsCommands[i + 2]);
                Ship ship = new Ship(shipName, shipMetalDeposit, shipMineralDeposit);
                ships.Add(ship);
            }

            bool isPlanetBuildingCommandsSendingActive = true;

            while (isPlanetBuildingCommandsSendingActive)
            {
                string[] planetBuildingCommand = Console.ReadLine().Split();

                if (planetBuildingCommand[0] == "END")
                {
                    isPlanetBuildingCommandsSendingActive = false;
                    break;
                }

                string planetName = planetBuildingCommand[0];

                Planet correspondingPlanet = planets
                    .Where(p => p.Name == planetName)
                    .FirstOrDefault();

                if (correspondingPlanet != null)
                {
                    string buildingOrShipName = planetBuildingCommand[1];

                    switch (buildingOrShipName)
                    {
                        case MetalMine:
                        case MineralMine:
                        case YardShip:
                            Building correspondingBuilding = buildings
                                .Where(b => b.Name == buildingOrShipName)
                                .FirstOrDefault();

                            if (correspondingBuilding != null)
                            {
                                correspondingPlanet.ConstructBuilding(correspondingBuilding);
                            }
                            break;
                        case Transporter:
                        case BattleShip:
                        case Fighter:
                            Ship correspondingShip = ships
                                .Where(s => s.Name == buildingOrShipName)
                                .FirstOrDefault();

                            int shipUnits = int.Parse(planetBuildingCommand[2]);

                            if (correspondingShip != null)
                            {
                                correspondingPlanet.ConstructShip(correspondingShip, shipUnits);
                            }
                            break;
                    }
                }
            }

            if (!isPlanetBuildingCommandsSendingActive)
            {
                Console.WriteLine("Resources:");

                foreach (Planet planet in planets) 
                {
                    Console.WriteLine($"{planet.Name} Metal {planet.Metal} Mineral {planet.Mineral}");
                }

                Console.WriteLine("Buildings:");

                foreach (Planet planet in planets)
                {
                    if (planet.Buildings.Any())
                    {
                        int metalMinesCount = planet.Buildings
                            .Where(b => b.Name == MetalMine)
                            .Count();

                        int mineralMinesCount = planet.Buildings
                            .Where(b => b.Name == MineralMine)
                            .Count();

                        int shipYardsCount = planet.Buildings
                            .Where(b => b.Name == YardShip)
                            .Count();

                        Console.WriteLine($"{planet.Name} {MetalMine} {metalMinesCount} {MineralMine} {mineralMinesCount} {YardShip} {shipYardsCount}");
                    }
                    else
                    {
                        Console.WriteLine($"On {planet.Name} there are not buildings");
                    }
                }

                Console.WriteLine("Ships:");

                foreach (Planet planet in planets)
                {
                    if (planet.Ships.Any())
                    {
                        int transportersCount = planet.Ships
                            .Where(s => s.Name == Transporter)
                            .Count();

                        int battleShipsCount = planet.Ships
                            .Where(s => s.Name == BattleShip)
                            .Count();

                        int fightersCount = planet.Ships
                            .Where(s => s.Name == Fighter)
                            .Count();

                        Console.WriteLine($"{planet.Name} {Transporter} {transportersCount} {BattleShip} {battleShipsCount} {Fighter} {fightersCount}");
                    }
                    else
                    {
                        Console.WriteLine($"On {planet.Name} there are not ships");
                    }
                }
            }
        }
    }
}

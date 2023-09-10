using System;

namespace DungeonestDark
{
    public class Hero
    {
        private int hp;

        private int coins;

        public Hero()
        {
            this.HP = 100;
            this.Coins = 0;
        }

        public int HP
        {
            get { return this.hp; }
            set { this.hp = value; }
        }

        public int Coins
        {
            get { return this.coins; }
            set { this.coins = value; }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRoomsCommands = Console.ReadLine().Split(new char[] { '|' });

            Hero hero = new Hero();

            int roomsCounter = 0;

            bool isDungeonRoomsCommandsSendingActive = true;

            for (int i = 0; i < dungeonRoomsCommands.Length; i++)
            {
                string[] dungeonRoomCommandDetails = dungeonRoomsCommands[i].Split();

                switch (dungeonRoomCommandDetails[0])
                {
                    case "potion":
                        int pointsToHeal = int.Parse(dungeonRoomCommandDetails[1]);

                        if (hero.HP + pointsToHeal > 100)
                        {
                            Console.WriteLine($"You healed for {100 - hero.HP} hp.");
                            hero.HP += 100 - hero.HP;
                        }
                        else
                        {
                            Console.WriteLine($"You healed for {pointsToHeal} hp.");
                            hero.HP += pointsToHeal;
                        }

                        Console.WriteLine($"Current health: {hero.HP} hp.");
                        roomsCounter++;
                        break;
                    case "chest":
                        int foundCoins = int.Parse(dungeonRoomCommandDetails[1]);
                        Console.WriteLine($"You found {foundCoins} coins.");
                        hero.Coins += foundCoins;
                        roomsCounter++;
                        break;
                    default:
                        int monsterAttack = int.Parse(dungeonRoomCommandDetails[1]);
                        hero.HP -= monsterAttack;
                        roomsCounter++;

                        if (hero.HP > 0)
                        {
                            Console.WriteLine($"You slayed {dungeonRoomCommandDetails[0]}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {dungeonRoomCommandDetails[0]}.");
                            Console.WriteLine($"Best room: {roomsCounter}");
                            isDungeonRoomsCommandsSendingActive = false;
                        }
                        break;
                }

                if (!isDungeonRoomsCommandsSendingActive)
                {
                    break;
                }
            }

            if (roomsCounter == dungeonRoomsCommands.Length)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Coins: {hero.Coins}");
                Console.WriteLine($"Health: {hero.HP}");
            }
        }
    }
}

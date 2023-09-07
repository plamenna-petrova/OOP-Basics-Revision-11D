using System;
using System.Collections.Generic;
using System.Linq;

namespace CaloriesForPizza
{
    // Exercise: Additional Problems Part 2 Task #1

    public class Pizza
    {
        private const int MinPizzaNameLength = 1;

        private const int MaxPizzaNameLength = 15;

        private const int MinNumberOfToppings = 0;

        private const int MaxNumberOfToppings = 10;

        private string name;

        private int numberOfToppings;

        private Dough dough;

        private List<Topping> toppings = new List<Topping>();

        public Pizza(string name, int numberOfTopings)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfTopings;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < MinPizzaNameLength || value.Length > MaxPizzaNameLength))
                {
                    throw new ArgumentException($"Pizza name should be between {MinPizzaNameLength} and {MaxPizzaNameLength} symbols.");
                } 

                this.name = value;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                return this.numberOfToppings;
            }

            set
            {
                if (value < MinNumberOfToppings || value > MaxNumberOfToppings)
                {
                    throw new ArgumentException($"Number of toppings should be in range [{MinNumberOfToppings}..{MaxNumberOfToppings}].");
                }

                this.numberOfToppings = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }

            set
            {
                this.dough = value;
            }
        }

        public List<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }

            set
            {
                this.toppings = value;
            }
        }

        public double GetTotalCalories()
        {
            return this.Dough.CalculateCalories() + this.Toppings.Sum(t => t.CalculateCalories());
        }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
        }
    }

    public class Dough
    {
        private const double WhiteDoughModificator = 1.5;

        private const double WholegrainDoughModificator = 1.0;

        private const double CrispyDoughModificator = 0.9;

        private const double ChewyDoughModificator = 1.1;

        private const double HomemadeDoughModificator = 1.0;

        private const int MinDoughWeight = 1;

        private const int MaxDoughWeight = 200;

        private FlourType flourType;

        private BakingTechnique bakingTechnique;

        private int weightInGrams;

        public Dough(string flourType, string bakingTechnique, int weightInGrams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.WeightInGrams = weightInGrams;
        }

        public string FlourType
        {
            get
            {
                return Enum.GetName(typeof(FlourType), this.flourType);
            }

            set
            {
                if (!Enum.GetNames(typeof(FlourType)).Select(ft => ft.ToLower()).ToList().Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = (FlourType)Enum.Parse(typeof(FlourType), value, true);
            }
        }

        public string BakingTechnique
        {
            get
            {
                return Enum.GetName(typeof(BakingTechnique), this.bakingTechnique);
            }

            set
            {
                if (!Enum.GetNames(typeof(BakingTechnique)).Select(bt => bt.ToLower()).ToList().Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = (BakingTechnique)Enum.Parse(typeof(BakingTechnique), value, true);
            }
        }

        public int WeightInGrams
        {
            get
            {
                return this.weightInGrams;
            }

            set
            {
                if (value < MinDoughWeight || value > MaxDoughWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinDoughWeight}..{MaxDoughWeight}]");
                }

                this.weightInGrams = value;
            }
        }

        public double CalculateCalories()
        {
            double flourTypeModificator = this.flourType == CaloriesForPizza.FlourType.White
                ? WhiteDoughModificator 
                : WholegrainDoughModificator;

            double bakingTechniqueModificator = this.bakingTechnique == CaloriesForPizza.BakingTechnique.Chewy 
                ? ChewyDoughModificator 
                : this.bakingTechnique == CaloriesForPizza.BakingTechnique.Crispy 
                    ? CrispyDoughModificator 
                    : HomemadeDoughModificator;

            return (2 * this.weightInGrams) * flourTypeModificator * bakingTechniqueModificator;
        }
    }

    public enum FlourType
    {
        White,
        Wholegrain
    }

    public enum BakingTechnique
    {
        Crispy,
        Chewy,
        Homemade
    }

    public class Topping
    {
        private const double MeatToppingModificator = 1.2;

        private const double VeggiesToppingModificator = 0.8;

        private const double CheeseToppingModificator = 1.1;

        private const double SauceToppingModificator = 0.9;

        private const int MinToppingWeight = 1;

        private const int MaxToppingWeight = 50;

        private ToppingType toppingType;

        private int weightInGrams;

        public Topping(string toppingType, int weightInGrams)
        {
            this.ToppingType = toppingType;
            this.WeightInGrams = weightInGrams;
        }

        public string ToppingType
        {
            get
            {
                return Enum.GetName(typeof(ToppingType), this.toppingType);
            }

            set
            {
                if (!Enum.GetNames(typeof(ToppingType)).Select(tt => tt.ToLower()).ToList().Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = (ToppingType)Enum.Parse(typeof(ToppingType), value, true);
            }
        }

        public int WeightInGrams
        {
            get
            {
                return this.weightInGrams;
            }

            set
            {
                if (value < MinToppingWeight || value > MaxToppingWeight)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [{MinToppingWeight}..{MaxToppingWeight}]");
                }

                this.weightInGrams = value;
            }
        }

        public double CalculateCalories()
        {
            double toppingTypeModificator = this.toppingType == CaloriesForPizza.ToppingType.Meat
                ? MeatToppingModificator
                : this.toppingType == CaloriesForPizza.ToppingType.Veggies
                    ? VeggiesToppingModificator
                    : this.toppingType == CaloriesForPizza.ToppingType.Cheese
                        ? CheeseToppingModificator
                        : SauceToppingModificator;

            return 2 * this.weightInGrams * toppingTypeModificator;
        }
    }

    public enum ToppingType
    {
        Meat,
        Veggies,
        Cheese,
        Sauce
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //bool isDoughCommandsSendingActive = true;

            //List<Dough> doughs = new List<Dough>();

            //while (isDoughCommandsSendingActive)
            //{
            //    string[] doughCommands = Console.ReadLine().Split();

            //    if (doughCommands[0] == "END")
            //    {
            //        isDoughCommandsSendingActive = false;
            //        break;
            //    }

            //    string flourType = doughCommands[1];
            //    string bakingTechnique = doughCommands[2];
            //    int weightInGrams = int.Parse(doughCommands[3]);

            //    Dough dough = new Dough(flourType, bakingTechnique, weightInGrams);
            //    Console.WriteLine($"{dough.CalculateCalories():F2}");
            //}

            //bool isDoughWithToppingCommandsSendingActive = true;

            //while (isDoughWithToppingCommandsSendingActive)
            //{
            //    string[] doughWithToppingCommands = Console.ReadLine().Split();

            //    switch (doughWithToppingCommands[0])
            //    {
            //        case "Dough":
            //            string doughFlourType = doughWithToppingCommands[1];
            //            string doughBakingTechnique = doughWithToppingCommands[2];
            //            int doughWeightInGrams = int.Parse(doughWithToppingCommands[3]);
            //            Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeightInGrams);
            //            Console.WriteLine($"{dough.CalculateCalories():F2}");
            //            break;
            //        case "Topping":
            //            string toppingType = doughWithToppingCommands[1];
            //            int toppingWeightInGrams = int.Parse(doughWithToppingCommands[2]);
            //            Topping topping = new Topping(toppingType, toppingWeightInGrams);
            //            Console.WriteLine($"{topping.CalculateCalories():F2}");
            //            break;
            //        case "END":
            //            isDoughWithToppingCommandsSendingActive = false;
            //            break;
            //    }
            //}

            string[] pizzaCommands = Console.ReadLine().Split();
            string pizzaName = pizzaCommands[1];
            int numberOfToppings = int.Parse(pizzaCommands[2]);
            Pizza pizza = new Pizza(pizzaName, numberOfToppings);

            string[] doughCommands = Console.ReadLine().Split();
            string doughFlourType = doughCommands[1];
            string doughBakingTechnique = doughCommands[2];
            int doughWeightInGrams = int.Parse(doughCommands[3]);
            Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeightInGrams);

            pizza.Dough = dough;

            bool isToppingsCommandsSendingActive = true;

            while (isToppingsCommandsSendingActive)
            {
                string[] toppingCommands = Console.ReadLine().Split();

                switch (toppingCommands[0])
                {
                    case "Topping":
                        string toppingType = toppingCommands[1];
                        int toppingWeightInGrams = int.Parse(toppingCommands[2]);
                        Topping topping = new Topping(toppingType, toppingWeightInGrams);
                        pizza.Toppings.Add(topping);
                        break;
                    case "END":
                        isToppingsCommandsSendingActive = false;
                        break;
                }
            }

            if (!isToppingsCommandsSendingActive)
            {
                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories.");
            }
        }
    }
}

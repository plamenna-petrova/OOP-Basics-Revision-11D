using System;
using System.Collections.Generic;
using System.Linq;

namespace OneShop
{
    public static class Shop
    {
        private static List<Product> products;

        static Shop()
        {
            Products = new List<Product>();
        }

        public static List<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
            }
        }

        public static void SellProduct(string barcode, double quantityForSale)
        {
            Product productToSell = Products
                .Where(p => p.Barcode == barcode)
                .FirstOrDefault();
            
            if (productToSell != null)
            {
                if (productToSell.Quantity < quantityForSale)
                {
                    Console.WriteLine("Not enough quantity");
                }
                else
                {
                    productToSell.Quantity -= quantityForSale;
                }
            }
            else
            {
                Console.WriteLine("Not enough quantity");
            }
        }

        public static void AddProduct(string barcode, string name, double price, double quantity)
        {
            Product productToFind = Products
                .Where(p => p.Barcode == barcode)
                .FirstOrDefault();

            if (productToFind == null)
            {
                Product productToAdd = new Product(name, barcode, price, quantity);
                Products.Add(productToAdd);
            }
        }

        public static void LoadProduct(string barcode, double quantity)
        {
            Product productToLoad = Products
                .Where(p => p.Barcode == barcode)
                .FirstOrDefault();

            if (productToLoad != null)
            {
                productToLoad.Quantity += quantity;
            }
            else
            {
                Console.WriteLine("Please add your product first!");
            }
        }

        public static void PrintProductsInAlphabeticalOrder()
        {
            List<Product> alphabeticallyOrderedProducts = Products
                .Where(p => p.Quantity > 0)
                .OrderBy(p => p.Name)
                .ToList();

            PrintProductsInfo(alphabeticallyOrderedProducts);
        }

        public static void PrintUnstockedProducts()
        {
            List<Product> unstockedProducts = Products
                .Where(p => p.Quantity == 0)
                .ToList();

            PrintProductsInfo(unstockedProducts);
        }

        public static void PrintProductsByDescendingQuantity()
        {
            List<Product> productsOrderedByDescendingQuantity = Products
                .Where(p => p.Quantity > 0)
                .OrderByDescending(p => p.Quantity)
                .ToList();

            PrintProductsInfo(productsOrderedByDescendingQuantity);
        }

        public static void CalculateTotalProductsPrice()
        {
            double totalProductsPrice = Products.Where(p => p.Quantity > 0).Sum(p => p.Price * p.Quantity);
            Console.WriteLine($"{totalProductsPrice:F2}");
        }

        private static void PrintProductsInfo(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }

    public class Product
    {
        private string name;

        private string barcode;

        private double price;

        private double quantity;

        public Product(string name, string barcode, double price, double quantity)
        {
            this.Name = name;
            this.Barcode = barcode;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Barcode
        {
            get
            {
                return this.barcode;
            }

            set
            {
                this.barcode = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        public double Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                this.quantity = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Barcode})"; 
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            bool isProductsCommandsSendingActive = true;

            while (isProductsCommandsSendingActive)
            {
                string[] productCommand = Console.ReadLine().Split().ToArray();

                switch (productCommand[0])
                {
                    case "Sell":
                        Shop.SellProduct(productCommand[1], double.Parse(productCommand[2]));
                        break;
                    case "Add":
                        Shop.AddProduct(productCommand[1], productCommand[2], double.Parse(productCommand[3]), double.Parse(productCommand[4]));
                        break;
                    case "Update":
                        Shop.LoadProduct(productCommand[1], double.Parse(productCommand[2]));
                        break;
                    case "PrintA":
                        Shop.PrintProductsInAlphabeticalOrder();
                        break;
                    case "PrintU":
                        Shop.PrintUnstockedProducts();
                        break;
                    case "PrintD":
                        Shop.PrintProductsByDescendingQuantity();
                        break;
                    case "Calculate":
                        Shop.CalculateTotalProductsPrice();
                        break;
                    case "Close":
                        isProductsCommandsSendingActive = false;
                        break;
                }
            }
        }
    }
}

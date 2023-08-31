using System;
using System.Collections.Generic;
using System.Linq;

namespace ManWithHisMoney
{
    // Exercise: Methods Task #3

    public class BankAccount
    {
        private int id;

        private double balance;

        public BankAccount()
        {

        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public void Deposit(double amount)
        {
            this.balance += amount;
        }

        public void Withdraw(double amount)
        {
            this.balance -= amount;
        }

        public override string ToString()
        {
            return $"Account {this.id}, balance: {this.balance}";
        }
    }

    public class Person
    {
        private string name;

        private int age;

        private List<BankAccount> bankAccounts = new List<BankAccount>();

        public Person()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public List<BankAccount> BankAccounts
        {
            get { return bankAccounts; }
            set { bankAccounts = value; }
        }

        public double GetBalance()
        {
            return this.bankAccounts.Sum(ba => ba.Balance);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Peter",
                Age = 28
            };

            BankAccount firstBankAccount = new BankAccount
            {
                ID = 1
            };

            firstBankAccount.Deposit(15);
            firstBankAccount.Withdraw(5);

            BankAccount secondBankAccount = new BankAccount
            {
                ID = 2
            };

            secondBankAccount.Deposit(25);
            secondBankAccount.Withdraw(3);

            person.BankAccounts.Add(firstBankAccount);
            person.BankAccounts.Add(secondBankAccount);

            double totalBalance = person.GetBalance();

            Console.WriteLine(totalBalance);
        }
    }
}

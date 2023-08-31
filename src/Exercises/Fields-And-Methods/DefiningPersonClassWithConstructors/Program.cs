using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningPersonClassWithConstructors
{
    // Exercise: Constructors Task #1

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

        private List<BankAccount> bankAccounts;

        //public Person(string name, int age)
        //{
        //    this.name = name;
        //    this.age = age;
        //    this.bankAccounts = new List<BankAccount>();
        //}

        //public Person(string name, int age, List<BankAccount> bankAccounts) : this(name, age)
        //{
        //    this.name = name;
        //    this.age = age;
        //    this.bankAccounts = bankAccounts;
        //}

        public Person(string name, int age, List<BankAccount> bankAccounts)
        {
            this.name = name;
            this.age = age;
            this.bankAccounts = bankAccounts;
        }

        public Person(string name, int age)
            : this(name, age, new List<BankAccount>())

        {

        }

        public double GetBalance()
        {
            return bankAccounts.Sum(ba => ba.Balance);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount firstBankAccount = new BankAccount();
            firstBankAccount.ID = 1;
            firstBankAccount.Deposit(15);
            firstBankAccount.Withdraw(5);

            BankAccount secondBankAccount = new BankAccount();
            secondBankAccount.ID = 2;
            secondBankAccount.Deposit(30);

            List<BankAccount> bankAccounts = new List<BankAccount>
            {
                firstBankAccount,
                secondBankAccount
            };

            //Person firstPerson = new Person("Gosho", 18);
            Person firstPerson = new Person("Gosho", 18, bankAccounts);
            double firstPersonTotalBalance = firstPerson.GetBalance();

            Console.WriteLine(firstPersonTotalBalance);
        }
    }
}

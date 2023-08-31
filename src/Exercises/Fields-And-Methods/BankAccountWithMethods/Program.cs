using System;

namespace BankAccountWithMethods
{
    // Exercise: Methods Task #2

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

    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.ID = 1;
            bankAccount.Deposit(15);
            bankAccount.Withdraw(5);

            Console.WriteLine(bankAccount.ToString());
        }
    }
}

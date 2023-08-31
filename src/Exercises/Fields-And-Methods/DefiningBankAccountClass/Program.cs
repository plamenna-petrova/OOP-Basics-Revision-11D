using System;

namespace DefiningBankAccountClass
{
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
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.ID = 1;
            bankAccount.Balance = 15;

            Console.WriteLine($"Account: {bankAccount.ID}, balance {bankAccount.Balance}");
        }
    }
}

using System;
namespace BankAppForUni
{
	public class BankAccounter:BankAccount
	{

        public decimal balance;

		public BankAccounter(decimal initialBalance)
		{
            balance = initialBalance;
		}

        public void AddMoney(decimal money)
        {
            if (money >= 0)
            {
                balance += money;
            }
            else
            {
                Console.WriteLine("money 0 dan boyuk olmadir!");
            }       
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void RemoveMoney(decimal money)
        {
            if (money <= balance)
            {
                balance -= money+money*5/100;
            }
            else
            {
                Console.WriteLine("xeta bash verdi hesabda kifayet qeder pul yoxdur");
            }          
        }
    }
}


using System;
namespace BankAppForUni
{
	public interface BankAccount
	{

		public decimal GetBalance();

		public void AddMoney(decimal money);

		public void RemoveMoney(decimal money);
	}
}


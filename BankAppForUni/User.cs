using System;
namespace BankAppForUni
{
    public class User
    {
        private string? _fullName;
        public List<BankAccounter> BankAccount;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public User(string fullName, List<BankAccounter> bankAccount)
        {
            FullName = fullName;
            BankAccount = bankAccount;
        }
    }
}


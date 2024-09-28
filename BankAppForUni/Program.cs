using BankAppForUni;

Console.WriteLine("Hello, World!");

Console.WriteLine("Zehmet olmasa full adinizi daxil edin:");
string fullName = Console.ReadLine();


BankAccounter bankAccounter = new BankAccounter(1000);
List<BankAccounter> accounts = new List<BankAccounter> { bankAccounter };


User user = new User(fullName, accounts);
string choice;

do
{
    Console.WriteLine("\nSeciminizi edin:");
    Console.WriteLine("1. Hesablara bax");
    Console.WriteLine("2. Yeni hesab elave et");
    Console.WriteLine("3. Pul yatir");
    Console.WriteLine("4. Pul cek");
    Console.WriteLine("5. Cix");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Hesablar:");
            for (int i = 0; i < user.BankAccount.Count; i++)
            {
                Console.WriteLine($"Hesab {i + 1}: {user.BankAccount[i].GetBalance()} manat");
            }
            break;

        case "2":
            Console.WriteLine("Yeni hesab balansi daxil edin:");
            if (decimal.TryParse(Console.ReadLine(), out decimal newBalance))
            {
                BankAccounter newAccount = new BankAccounter(newBalance);
                user.BankAccount.Add(newAccount);
                Console.WriteLine("Yeni hesab elave edildi.");
            }
            else
            {
                Console.WriteLine("Xeta: Dogru balans daxil edin.");
            }
            break;

        case "3":
            Console.WriteLine("Pul yatir: Hansı hesaba yatirilsin? (1, 2, 3...)");
            int depositAccountIndex;
            if (int.TryParse(Console.ReadLine(), out depositAccountIndex) && depositAccountIndex > 0 && depositAccountIndex <= user.BankAccount.Count)
            {
                decimal depositMoney;
                string moneyInput;

                do
                {
                    Console.WriteLine("Yatiracaginiz pulu daxil edin:");
                    moneyInput = Console.ReadLine();
                } while (!decimal.TryParse(moneyInput, out depositMoney) || depositMoney < 0);

                user.BankAccount[depositAccountIndex - 1].AddMoney(depositMoney);
                Console.WriteLine($"Hormetli {user.FullName}, sizin {depositAccountIndex}. hesabınıza {depositMoney} manat elave olundu.");
            }
            else
            {
                Console.WriteLine("Xeta: Duzgun hesab nomresini daxil edin.");
            }
            break;

        case "4":
            Console.WriteLine("Pul cek: Hansı hesaba cekilsin? (1, 2, 3...)");
            int withdrawAccountIndex;
            if (int.TryParse(Console.ReadLine(), out withdrawAccountIndex) && withdrawAccountIndex > 0 && withdrawAccountIndex <= user.BankAccount.Count)
            {
                Console.WriteLine("Cekilecek meblegi daxil edin:");
                decimal withdrawalAmount;
                if (decimal.TryParse(Console.ReadLine(), out withdrawalAmount))
                {
                    user.BankAccount[withdrawAccountIndex - 1].RemoveMoney(withdrawalAmount);
                    Console.WriteLine($"Hormetli {user.FullName}, sizin {withdrawAccountIndex}. hesabinizdan {withdrawalAmount + withdrawalAmount * 5 / 100} manat cixildi.");
                }
                else
                {
                    Console.WriteLine("Xeta: Dogru mebleg daxil edin.");
                }
            }
            else
            {
                Console.WriteLine("Xeta: Duzgun hesab nomresini daxil edin.");
            }
            break;

        case "5":
            Console.WriteLine("Programdan cixirsiniz.");
            break;

        default:
            Console.WriteLine("Yanlis secim etdiniz. Zehmet olmasa yeniden cehd edin.");
            break;
    }

} while (choice != "5");

namespace Task_4
{

    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = " ", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Name} - Balance: {Balance:C}";
        }
        public static Account operator +(Account lhs, Account rhs)
        {
            Account account = new Account(lhs.Name + " " + rhs.Name, lhs.Balance + rhs.Balance);
            return account;
        }
    }
    public class SavingAccount : Account
    {
        public SavingAccount(string Name = " ", double Balance = default, double Rate = default) : base(Name, Balance)
        {
            this.Rate = Rate;
        }

        public double Rate { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()},Rate : {Rate}";
        }
    }
    public class CheckingAccount : Account
    {
        public CheckingAccount(string name =" ", double Balance = default, double fee = 1.5) : base(name, Balance)
        {
            Fee = fee;
        }

        public double Fee { get; set; }
        public override bool Withdraw(double amount)
        {
            if (Balance - (amount + Fee) >= 0)
            {
                bool success = base.Withdraw(amount);
                if (success)
                {
                    Balance -= Fee;
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
    public class TrustAccount : SavingAccount               //تم الاستعانة بـ شات جي بي تي لاكمال جزئية التحقق من عدد مرات السحب في السنة الموضحة في الاسطر المرقمة في الكومنت 
    {
        private int limitcount = 0;
        private const int maximumcount = 3;
        private const int money = 5000;
        private const int bouns = 50;
        private DateTime dateCreatT;                       //  1 


        public TrustAccount(string Name = " ", double Balance = default, double Rate = default) : base(Name, Balance, Rate)
        {
             this.dateCreatT = DateTime.Now;               //2
        }
        public override bool Deposit(double amount)
        {
            if (amount >= money) 
            {
                Balance += bouns;
                Console.WriteLine($"Bouns of{bouns:C} is Added to Accont for Deposit {amount:C}");
            }
            return base.Deposit(amount);
        }
        public override bool Withdraw(double amount)
        {
                                                                   
            if ((DateTime.Now - dateCreatT).TotalDays >= 365)                     // 3
            {
                limitcount = 0;          //4
                dateCreatT = DateTime.Now;          // 5
                Console.WriteLine("A new year has started, withdrawal attempts reset.");            //6
            }

            if (limitcount >= maximumcount)
            {
                DateTime openWithdraw = dateCreatT.AddYears(1);          // 7
                Console.WriteLine("You have exceeded the number of withdrawals allowed per year.");     ///8
                Console.WriteLine($"You can withdraw again in: {openWithdraw}");                //9
                return false;

            }
            else if (amount <= Balance * 0.20)
            {
                limitcount++;
                Console.WriteLine($"Withdraw {amount:C} complet successfull, The number of attempts will be renewed in {dateCreatT}");      //10
                return base.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("The withdrawn amount exceeded 20 % ");
                return false;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()} , Withdraw Limit : {maximumcount - limitcount}";
        }
    }
   public static class AccountUtil
{
    // Utility helper functions for Account class

    public static void Display(List<Account> accounts)
    {
        Console.WriteLine("\n=== Accounts ==========================================");
        foreach (var acc in accounts)
        {
            Console.WriteLine(acc);
        }
    }

    public static void Deposit(List<Account> accounts, double amount)
    {
        Console.WriteLine("\n=== Depositing to Accounts =================================");
        foreach (var acc in accounts)
        {
            if (acc.Deposit(amount))
                Console.WriteLine($"Deposited {amount} to {acc}");
            else
                Console.WriteLine($"Failed Deposit of {amount} to {acc}");
        }
    }

    public static void Withdraw(List<Account> accounts, double amount)
    {
        Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
        foreach (var acc in accounts)
        {
            if (acc.Withdraw(amount))
                Console.WriteLine($"Withdrew {amount} from {acc}");
            else
                Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
        }
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var account = new List<Account>();
            account.Add(new Account());
            account.Add(new Account("Larry"));
            account.Add(new Account("Moe", 2000));
            account.Add(new Account("Curly", 5000));

            AccountUtil.Display(account);
            AccountUtil.Deposit(account, 1000);
            AccountUtil.Withdraw(account, 2000);

            //Savings
            var savAccounts = new List<SavingAccount>();
            account.Add(new SavingAccount());
            account.Add(new SavingAccount("Superman"));
            account.Add(new SavingAccount("Batman", 2000));
            account.Add(new SavingAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Display(account);
            AccountUtil.Deposit(account, 1000);
            AccountUtil.Withdraw(account, 2000);

            //// Checking
            var checAccounts = new List<CheckingAccount>();
            account.Add(new CheckingAccount());
            account.Add(new CheckingAccount("Larry2"));
            account.Add(new CheckingAccount("Moe2", 2000));
            account.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Display(account);
            AccountUtil.Deposit(account, 1000);
            AccountUtil.Withdraw(account, 2000);
            AccountUtil.Withdraw(account, 2000);

            //// Trust
            var trustAccounts = new List<TrustAccount>();
            account.Add(new TrustAccount());
            account.Add(new TrustAccount("Superman2"));
            account.Add(new TrustAccount("Batman2", 2000));
            account.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Display(account);
            AccountUtil.Deposit(account, 1000);
            AccountUtil.Deposit(account, 6000);
            AccountUtil.Withdraw(account, 2000);
            AccountUtil.Withdraw(account, 3000);
            AccountUtil.Withdraw(account, 500);
            AccountUtil.Withdraw(account, 500);
            AccountUtil.Withdraw(account, 500);


        }
    }
}






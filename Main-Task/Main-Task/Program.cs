namespace Main_Task;

class Program
{
    static void Main(string[] args)
    {
        // Accounts
        var accounts = new List<Account>();
        accounts.Add(new Account("Larry"));
        accounts.Add(new Account("Moe", 2000));
        accounts.Add(new Account("Curly", 5000));

        AccountUtil.Deposit(accounts, 1000);
        AccountUtil.Withdraw(accounts, 2000);

        // Savings
        List<Account> savAccounts = new List<Account>();
        savAccounts.Add(new clsSavingAccount("Superman"));
        savAccounts.Add(new clsSavingAccount("Batman", 2000));
        savAccounts.Add(new clsSavingAccount("Wonderwoman", 5000, 5.0F));

        AccountUtil.Deposit(savAccounts, 1000);
        AccountUtil.Withdraw(savAccounts, 2000);

        // Checking
        List<Account> checAccounts = new List<Account>();
        checAccounts.Add(new CheckingAccount("Larry2"));
        checAccounts.Add(new CheckingAccount("Moe2", 2000));
        checAccounts.Add(new CheckingAccount("Curly2", 5000));

        AccountUtil.Deposit(checAccounts, 1000);
        AccountUtil.Withdraw(checAccounts, 2000);
        AccountUtil.Withdraw(checAccounts, 2000);

        // Trust
        List<Account> trustAccounts = new List<Account>();
        trustAccounts.Add(new clsTrustAccount("Superman2"));
        trustAccounts.Add(new clsTrustAccount("Batman2", 2000));
        trustAccounts.Add(new clsTrustAccount("Wonderwoman2", 5000, 5.0));

        AccountUtil.Deposit(trustAccounts, 1000);
        AccountUtil.Deposit(trustAccounts, 6000);
        AccountUtil.Deposit(trustAccounts, 2000);
        AccountUtil.Withdraw(trustAccounts, 3000);
        AccountUtil.Withdraw(trustAccounts, 500);
        Console.WriteLine();
        
        AccountUtil.Print(checAccounts);
        AccountUtil.Print(savAccounts);
        AccountUtil.Print(accounts);
        AccountUtil.Print(trustAccounts);
        
    }
    
    
}
public static class AccountUtil
{
    // Utility helper functions for Account class
    public static void Deposit(List<Account> accounts, double amount)
    {
        Console.WriteLine("\n=== Depositing to Accounts =================================");
        foreach (var acc in accounts)
        {
            if (acc.Deposit(amount))
                Console.WriteLine($"Deposited {amount} to {acc.Name}");
            else
                Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
        }
    }

    public static void Withdraw(List<Account> accounts, double amount)
    {
        Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
        foreach (var acc in accounts)
        {
            if (acc.Withdraw(amount))
                Console.WriteLine($"Withdrew {amount} from {acc.Name}");
            else
                Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
        }
    }

    public static void Print(List<Account> accounts)
    {
        Console.WriteLine("\n====================================\nPrinting \n====================================");
        foreach (var acc in accounts)
        {
            Console.WriteLine(acc.Name + ": " + acc.Balance);
            
        }
    }
}

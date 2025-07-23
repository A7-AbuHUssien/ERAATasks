namespace Main_Task;

public class clsSavingAccount : Account
{
    public double InterestRate;

    public clsSavingAccount(string name, double amount = 0.0, double interestRate = 0.01) : base(name, amount)
    {
        InterestRate = interestRate;
    }

    public override bool Deposit(double amount)
    {
        return base.Deposit(amount + (amount * InterestRate));
    }
}
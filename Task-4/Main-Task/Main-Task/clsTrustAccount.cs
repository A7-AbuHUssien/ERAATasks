namespace Main_Task;

public class clsTrustAccount : Account
{
    private short CountOfWithdraw = 3;
    public double InterestRate  { get; set; }

    public clsTrustAccount(string name, double balance =0.0, double interestRate =0.0) : base(name , balance)
    {
        InterestRate = interestRate;
        if (balance > 5000)
            this.Deposit(50);
    }

    public override bool Deposit(double amount)
    {
        return base.Deposit(amount + InterestRate);
    }

    public override bool Withdraw(double amount)
    {
        if (CountOfWithdraw==0 || amount > 0.2 * Balance)
            return false;
        CountOfWithdraw--;
        return base.Withdraw(amount);
    }
}
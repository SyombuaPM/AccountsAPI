namespace AccountApi;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public double Balance { get; set; }
    public DateTime DateCreated { get; set; }

    public Account(int id, string name, string status, double balance, DateTime dateCreated)
    {
        Id = id;
        Name = name;
        Status = status;
        Balance = balance;
        DateCreated = dateCreated;
    }
    public void UpdateBalance(double amount)
    {
        // to test if the balance is sufficient to withdraw
        if (amount < 0 && Balance < Math.Abs(amount))
        {
            throw new Exception("Insufficient funds");
        }

        if (amount < 0 && Status.ToLower() != "yes")
        {
            throw new Exception("Account is not active");
        }

        if (amount < 0 && amount %50 != 0)
        {
            throw new Exception("Amount must be in multiples of 50");
        }

        
        Balance += amount;
    }

    public void updateStatus(string newStatus)
    {
        if (newStatus.ToLower() != "yes" && newStatus.ToLower() != "no")
        {
            throw new Exception("Invalid status");
        }
        Status = newStatus;
    }
    

}

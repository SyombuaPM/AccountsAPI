using Microsoft.EntityFrameworkCore;

namespace AccountApi;

public class AccountDbContext: DbContext
{
    public DbSet<Account> Accounts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Account.db");
        //optionsBuilder.UseInMemoryDatabase("Account");
    }


}

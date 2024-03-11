using Microsoft.EntityFrameworkCore;

namespace AccountApi;

public class AccountService
{
    private readonly AccountDbContext _context;

    public AccountService(AccountDbContext context)
    {
        _context = context;
    }

    public Account CreateAccount(string name, string status, double balance)
    {
        var account = new Account(0, name, status, balance, DateTime.Now);
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return account;
    }

    public Account? GetAccount(int id)
    {
        return _context.Accounts.Find(id);
    }

    public async Task<Account?> GetAccountAsync(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _context.Accounts.ToList();
    }

    public async Task<List<Account>> GetAccountsAsync()
    {
        var list = _context.Accounts.ToListAsync();
        return await list;
    }

    public async Task<Account> InsertAccountAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public void UpdateAccount(Account account)
    {
        _context.Entry(account).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public async Task UpdateAccountAsync(Account account)
    {
        _context.Entry(account).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }


    public void DeleteAccount(int id)
    {
        var account = _context.Accounts.Find(id);
        _context.Accounts.Remove(account);
        _context.SaveChanges();
    }
    
}

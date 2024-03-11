using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AccountApi;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("{id}")]
    public ActionResult<Account> GetAccount(int id)
    {
        var account = _accountService.GetAccount(id);
        if (account == null)
        {
            return NotFound();
        }
        return account;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Account>> GetAccounts()
    {
        return _accountService.GetAccounts().ToList();
    }

    [HttpPost]
    public ActionResult<Account> CreateAccount([FromBody]Account account)
    {
        var newAccount = _accountService.InsertAccountAsync(account);
        return CreatedAtAction(nameof(CreateAccount), new { id = newAccount.Id }, newAccount);
    }

    [HttpPatch("withdraw/{id}")]
    public ActionResult<Account> Withdraw(int id, [FromBody] double amount)
    {
        try
        {
            var account = _accountService.GetAccount(id);
            account.UpdateBalance(0-amount);
            _accountService.UpdateAccount(account);
            return account;
        }
        catch (Exception e)
        {
            return BadRequest(new { Error = e.Message });
        }
    }
    
    [HttpPatch("deposit/{id}")]
    public ActionResult<Account> Deposit(int id, [FromBody] double amount)
    {
        try
        {
            var account = _accountService.GetAccount(id);
            account.UpdateBalance(amount);
            _accountService.UpdateAccount(account);
            return account;
        }
        catch (Exception e)
        {
            return BadRequest(new { Error = e.Message });
        }
    }

    
    

   

}

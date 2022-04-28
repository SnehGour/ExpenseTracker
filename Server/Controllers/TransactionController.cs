using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/transaction")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository _transactionRepo;
    public TransactionController(ITransactionRepository transactionRepo)
    {
        _transactionRepo = transactionRepo;
    }
    [HttpGet(Name = "getAllTransaction")]
    public IActionResult getAllTransactions()
    {
        var transactionList = _transactionRepo.GetTransactions();
        return Ok(transactionList);
    }

    [HttpPost(Name = "addTransaction")]
    public IActionResult AddTransaction(Transaction transaction)
    {
        if (transaction == null)
        {
            return BadRequest(ModelState);
        }

        transaction.CreatedAt = DateTime.Now;
        _transactionRepo.AddTransactions(transaction);
        var allTranscation = _transactionRepo.GetTransactions();
        return Ok(allTranscation);
    }

    [HttpDelete(Name = "deleteTransaction")]
    public IActionResult DeleteTransaction(int id)
    {
        if (id == null)
        {
            return BadRequest(ModelState);
        }
        _transactionRepo.DeleteTransaction(id);
        var remainingTransactionList = _transactionRepo.GetTransactions();
        return Ok(remainingTransactionList);
    }
}
public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _db;
    public TransactionRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public bool AddTransactions(Transaction transaction)
    {
        _db.transactionsTbl.Add(transaction);
        return Save();
    }

    public bool DeleteTransaction(int id)
    {
        if(id == null)
        {
            return false;
        }
        _db.transactionsTbl.Remove(new Transaction { Id = id });
        return Save();
    }

    public ICollection<Transaction> GetTransactions()
    {
        return _db.transactionsTbl.ToList();
    }

    public bool Save()
    {
        return _db.SaveChanges() >=0 ? true : false;
    }
}
public interface ITransactionRepository
{
    ICollection<Transaction> GetTransactions();
    bool AddTransactions(Transaction transaction);
    bool DeleteTransaction(int id);
    bool Save();
}
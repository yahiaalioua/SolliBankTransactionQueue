using AzureQueueStorageBankTransactions.Models;

namespace AzureQueueStorageBankTransactions.Brokers.Storage
{
    public class StorageBroker : IStorageBroker
    {
        private static List<BankTransaction> _transactions = new();

        public void Add(BankTransaction transaction)
        {
            _transactions.Add(transaction);
        }
        public List<BankTransaction> GetTransactions()
        {
            return _transactions;
        }

    }
}

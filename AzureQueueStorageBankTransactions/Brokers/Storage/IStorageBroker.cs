using AzureQueueStorageBankTransactions.Models;

namespace AzureQueueStorageBankTransactions.Brokers.Storage
{
    public interface IStorageBroker
    {
        void Add(BankTransaction transaction);
        List<BankTransaction> GetTransactions();
    }
}
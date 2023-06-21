using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;
using AzureQueueStorageBankTransactions.Models;

namespace AzureQueueStorageBankTransactions.Services.Processing
{
    public interface IProcessTransaction
    {
        void AddTransactionToDatabase(BankTransaction bankTransaction);
        Task AddBankTransactionToQueue(BankTransaction transaction);
        List<BankTransaction> GetAllTransactions();
    }
}
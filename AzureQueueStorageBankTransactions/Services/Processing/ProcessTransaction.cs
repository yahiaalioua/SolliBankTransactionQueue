using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using AzureQueueStorageBankTransactions.Brokers.Messaging;
using AzureQueueStorageBankTransactions.Brokers.Storage;
using AzureQueueStorageBankTransactions.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System.Transactions;

namespace AzureQueueStorageBankTransactions.Services.Processing
{
    public class ProcessTransaction : IProcessTransaction
    {
        private readonly IQueueBroker _queueBroker;
        private readonly IStorageBroker _storageBroker;

        public ProcessTransaction(IQueueBroker queueBroker, IStorageBroker storageBroker)
        {
            _queueBroker = queueBroker;
            _storageBroker = storageBroker;
        }
        public void AddTransactionToDatabase(BankTransaction bankTransaction)
        {
            if (bankTransaction != null)
            {
                _storageBroker.Add(bankTransaction);
            }
        }
        public async Task AddBankTransactionToQueue(BankTransaction transaction)
        {
            if(_queueBroker.GetBankTransactionsQueue().Exists())
                await _queueBroker.Publish(transaction);
        }

        public List<BankTransaction> GetAllTransactions()
        {
            return _storageBroker.GetTransactions();
        }
    }
}

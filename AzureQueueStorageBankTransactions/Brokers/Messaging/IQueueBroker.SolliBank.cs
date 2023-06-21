using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using AzureQueueStorageBankTransactions.Models;

namespace AzureQueueStorageBankTransactions.Brokers.Messaging
{
    public partial interface IQueueBroker
    {
        Task Publish(BankTransaction transaction);
        Task<QueueMessage[]> Consume(int? maxMessages = null);
        QueueClient GetBankTransactionsQueue();
        Task Delete(QueueMessage message);
    }
}

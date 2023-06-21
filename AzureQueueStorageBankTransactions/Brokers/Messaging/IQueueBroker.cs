using Azure.Storage.Queues;

namespace AzureQueueStorageBankTransactions.Brokers.Messaging
{
    public partial interface IQueueBroker
    {
        QueueClient GetQueueClient(string queueName);
    }
}
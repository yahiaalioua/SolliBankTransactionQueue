using AzureQueueStorageBankTransactions.Models;

namespace AzureQueueStorageBankTransactions.Brokers.Messaging
{
    public partial interface IQueueBroker
    {
        Task PublishToDeadLetter(BankTransaction transaction);
    }
}

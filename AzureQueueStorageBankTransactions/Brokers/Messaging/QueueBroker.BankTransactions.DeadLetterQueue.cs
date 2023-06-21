using Azure.Storage.Queues;
using AzureQueueStorageBankTransactions.Models;
using Newtonsoft.Json;

namespace AzureQueueStorageBankTransactions.Brokers.Messaging
{
    public partial class QueueBroker:IQueueBroker
    {
        public QueueClient DeadLetterQueue { get; private set; }
        public string DeadLetterQueueName { get; private set; } = "deadLetterBTQueue";

        public async Task PublishToDeadLetter(BankTransaction bankTransaction)
        {
            await DeadLetterQueue.SendMessageAsync(JsonConvert.SerializeObject(bankTransaction));
        }


    }
}

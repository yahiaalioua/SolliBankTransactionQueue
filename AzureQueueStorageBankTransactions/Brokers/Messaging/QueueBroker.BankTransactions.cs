using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using AzureQueueStorageBankTransactions.Models;
using Newtonsoft.Json;

namespace AzureQueueStorageBankTransactions.Brokers.Messaging
{
    public partial class QueueBroker:IQueueBroker
    {
        public string BankTransactionsQueueName { get; private set; } = "sollibankqueue";
        public QueueClient SolliBankQueue { get; private set; }

        public async Task Publish(BankTransaction transaction)=> 
            await SolliBankQueue.SendMessageAsync(JsonConvert.SerializeObject(transaction));
        public QueueClient GetBankTransactionsQueue() =>
            SolliBankQueue;
        public async Task<QueueMessage[]> Consume(int? maxMessages = null)
        {
            var message = await SolliBankQueue.ReceiveMessagesAsync(maxMessages);
            return message;
        }
        
        public async Task Delete(QueueMessage message)=>
            await SolliBankQueue.DeleteMessageAsync(message.MessageId,message.PopReceipt);
    }
}

using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;
using AzureQueueStorageBankTransactions.Brokers.Messaging;
using AzureQueueStorageBankTransactions.Brokers.Storage;
using AzureQueueStorageBankTransactions.Models;
using Newtonsoft.Json;

namespace AzureQueueStorageBankTransactions.Services.Background.Queue
{
    public class BankTransactionQueueConsumerService : BackgroundService
    {
        private readonly IQueueBroker _queueBroker;
        private readonly IStorageBroker _storageBroker;

        public BankTransactionQueueConsumerService(IQueueBroker queueBroker, IStorageBroker storageBroker)
        {
            _queueBroker = queueBroker;
            _storageBroker = storageBroker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            while(!stoppingToken.IsCancellationRequested)
            {
                QueueClient queueClient = _queueBroker.GetBankTransactionsQueue();
                if (queueClient.Exists())
                {
                    int? messageCount = queueClient.GetProperties().Value.ApproximateMessagesCount;
                    if (messageCount > 0)
                    {
                        QueueMessage[] lastMessages = await _queueBroker.Consume(1);
                        QueueMessage lastMessage = lastMessages[0];
                        BankTransaction transaction = JsonConvert.DeserializeObject<BankTransaction>(lastMessage.Body.ToString())!;
                        try
                        {
                            _storageBroker.Add(transaction);
                            await _queueBroker.Delete(lastMessage);
                        }
                        catch (Exception)
                        {
                            await _queueBroker.PublishToDeadLetter(transaction);
                            //slett melding fra hoved queue når den er blitt overført til dead letter
                            await _queueBroker.Delete(lastMessage);
                        }
                    }
                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
            }
        }
    }
}

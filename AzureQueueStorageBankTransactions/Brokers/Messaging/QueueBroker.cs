using Azure.Storage.Queues;

namespace AzureQueueStorageBankTransactions.Brokers.Messaging
{
    public partial class QueueBroker:IQueueBroker
    {
        private readonly IConfiguration _configuration;

        public QueueBroker(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeQueueClient();
        }
        public void InitializeQueueClient()
        {
            this.SolliBankQueue = GetQueueClient(BankTransactionsQueueName);
            this.DeadLetterQueue = GetQueueClient(DeadLetterQueueName);
        }
        public QueueClient GetQueueClient(string queueName)
        {
            string connStr = _configuration.GetConnectionString("AzureQueueStorageConnStr")!;
            return new QueueClient(connStr, queueName);
        }
    }
}

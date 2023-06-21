namespace AzureQueueStorageBankTransactions.Models
{
    public class BankTransaction
    {
        public Guid TransactionId { get; private set; }=Guid.NewGuid();
        public DateTime Date { get; private set; } = DateTime.UtcNow;
        public string AccountNumberSender { get; init; } = null!;
        public string AccountNumberReceiver { get; init; } = null!;
        public int Amount { get; init; }


    }
}

using AzureQueueStorageBankTransactions.Brokers.Messaging;
using AzureQueueStorageBankTransactions.Brokers.Storage;
using AzureQueueStorageBankTransactions.Services.Background.Queue;
using AzureQueueStorageBankTransactions.Services.Processing;

namespace AzureQueueStorageBankTransactions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IProcessTransaction, ProcessTransaction>();
            services.AddSingleton<IStorageBroker, StorageBroker>();
            services.AddTransient<IQueueBroker, QueueBroker>();
            services.AddHostedService<BankTransactionQueueConsumerService>();
            return services;
        }
    }
}

using AzureQueueStorageBankTransactions.Brokers.Messaging;
using AzureQueueStorageBankTransactions.Brokers.Storage;
using AzureQueueStorageBankTransactions.DependencyInjection;
using AzureQueueStorageBankTransactions.Services.Background.Queue;
using AzureQueueStorageBankTransactions.Services.Processing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

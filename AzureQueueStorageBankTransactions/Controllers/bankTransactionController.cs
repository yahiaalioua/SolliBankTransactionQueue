using AzureQueueStorageBankTransactions.Brokers.Messaging;
using AzureQueueStorageBankTransactions.Brokers.Storage;
using AzureQueueStorageBankTransactions.Models;
using AzureQueueStorageBankTransactions.Services.Processing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureQueueStorageBankTransactions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bankTransactionController : ControllerBase
    {
        private readonly IProcessTransaction _processTransaction;

        public bankTransactionController(IProcessTransaction processTransaction)
        {
            _processTransaction = processTransaction;
        }

        [HttpPost]
        public async Task<IActionResult> PostBankTransaction(BankTransaction bankTransaction)
        {
            await _processTransaction.AddBankTransactionToQueue(bankTransaction);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetBankTransaction()
        {
            var response=_processTransaction.GetAllTransactions();
            return Ok(response);
        }
    }
}

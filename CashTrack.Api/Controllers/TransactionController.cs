using CashTrack.Application.DTOs;
using CashTrack.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashTrack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET: api/transaction - Returns all transactions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionService.GetAllAsync();
            return Ok(transactions);
        }

        // GET: api/transaction/5 - Returns single transaction by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        // POST: api/transaction - Creates new transaction
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto createDto)
        {
            var transaction = await _transactionService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
        }

        // PUT: api/transaction/5 - Updates existing transaction
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTransactionDto updateDto)
        {
            var transaction = await _transactionService.UpdateAsync(id, updateDto);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        // DELETE: api/transaction/5 - Deletes transaction
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _transactionService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
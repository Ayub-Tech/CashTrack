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

        // Constructor injection
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET: api/Transaction
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_transactionService.GetAll());
        }

        // GET: api/Transaction/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactionService.GetById(id);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        // POST: api/Transaction
        [HttpPost]
        public IActionResult Create([FromBody] TransactionDto dto)
        {
            _transactionService.Create(dto);
            return Ok();
        }

        // PUT: api/Transaction/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TransactionDto dto)
        {
            var updated = _transactionService.Update(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Transaction/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _transactionService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
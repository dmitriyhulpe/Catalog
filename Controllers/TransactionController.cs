using Catalog.Interfaces.IUnitOfWork;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;

        public TransactionController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetT()
        {
            return Ok(await UnitOfWork.Transaction.Get());
        }

        [HttpPost]
        public async Task<ActionResult> CreateT(Transaction table)
        {
            await UnitOfWork.Transaction.Add(table);
            await UnitOfWork.Complete();
            return NoContent();
        }

        [HttpGet("{turnamentsID}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetT(int turnamentsID)
        {
            return Ok(await UnitOfWork.Transaction.GetById(turnamentsID));
        }

        [HttpDelete("{turnamentsID}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> DeleteT(int turnamentsID)
        {

            await UnitOfWork.Transaction.Delete(turnamentsID);
            await UnitOfWork.Complete();
            return NoContent();
        }
    }
}

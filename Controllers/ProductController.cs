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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProductController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetT()
        {
            return Ok(await UnitOfWork.Product.Get());
        }

        [HttpPost]
        public async Task<ActionResult> CreateT(Product table)
        {
            await UnitOfWork.Product.Add(table);
            await UnitOfWork.Complete();
            return NoContent();
        }

        [HttpGet("{turnamentsID}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetT(int turnamentsID)
        {
            return Ok(await UnitOfWork.Product.GetById(turnamentsID));
        }

        [HttpDelete("{turnamentsID}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteT(int turnamentsID)
        {

            await UnitOfWork.Product.Delete(turnamentsID);
            await UnitOfWork.Complete();
            return NoContent();
        }
    }
}

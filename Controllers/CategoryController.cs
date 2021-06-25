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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;

        public CategoryController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetT()
        {
            return Ok(await UnitOfWork.Category.Get());
        }

        [HttpPost]
        public async Task<ActionResult> CreateT(Category user)
        {
            await UnitOfWork.Category.Add(user);
            await UnitOfWork.Complete();
            return NoContent();
        }

        [HttpGet("{ClientID}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetT(int ClientID)
        {
            return Ok(await UnitOfWork.Category.GetById(ClientID));
        }

        [HttpDelete("{ClientID}")]
        public async Task<ActionResult<IEnumerable<Category>>> DeleteT(int ClientID)
        {
            await UnitOfWork.Category.Delete(ClientID);
            await UnitOfWork.Complete();
            return NoContent();
        }
    }
}

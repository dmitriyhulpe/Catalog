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
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;

        public MemberController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetT()
        {
            return Ok(await UnitOfWork.Member.Get());
        }

        [HttpPost]
        public async Task<ActionResult> CreateT(Member user)
        {
            await UnitOfWork.Member.Add(user);
            await UnitOfWork.Complete();
            return NoContent();
        }

        [HttpGet("{ClientID}")]
        public async Task<ActionResult<IEnumerable<Member>>> GetT(int ClientID)
        {
            return Ok(await UnitOfWork.Member.GetById(ClientID));
        }

        [HttpDelete("{ClientID}")]
        public async Task<ActionResult<IEnumerable<Member>>> DeleteT(int ClientID)
        {

            await UnitOfWork.Member.Delete(ClientID);
            await UnitOfWork.Complete();
            return NoContent();
        }
    }
}

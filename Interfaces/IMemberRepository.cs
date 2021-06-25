using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Interfaces.IGenericRepository;
using Catalog.Models;

namespace Catalog.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        
    }
}

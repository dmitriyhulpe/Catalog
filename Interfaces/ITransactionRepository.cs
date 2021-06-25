using Catalog.Interfaces.IGenericRepository;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        
    }
}
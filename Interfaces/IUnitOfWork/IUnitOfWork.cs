using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IMemberRepository Member { get; }
        ICategoryRepository Category { get; }
        ITransactionRepository Transaction { get; }
        Task<int> Complete();
    }
}
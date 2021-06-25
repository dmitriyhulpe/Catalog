using Catalog.Interfaces;
using Catalog.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context Context;
        public UnitOfWork(Context Context, IProductRepository product, IMemberRepository member, ICategoryRepository category, ITransactionRepository transaction)
        {
            this.Context = Context;

            Product = product;
            Member = member;
            Category = category;
            Transaction = transaction;
        }

        public IProductRepository Product { get; }
        public IMemberRepository Member { get; }
        public ICategoryRepository Category { get; }
        public ITransactionRepository Transaction { get; }
        public Task<int> Complete() => Context.SaveChangesAsync();
    }
}

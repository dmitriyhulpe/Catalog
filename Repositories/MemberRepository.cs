using Catalog.Interfaces;
using Catalog.Repositories.GenericRepository;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(Context context) : base(context)
        {

        }
    }
}
using Catalog.DTO;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Interfaces.IServices
{
    public interface IProductService
    {
        Task<ProductDTO> UpdateTable(ProductDTO obj);
        Task<ProductDTO> GetTableByID(int? id);
        Task<Product> DeleteTable(int id);
        Task<Product> AddTable(ProductDTO obj);
        Task<IEnumerable<ProductDTO>> GetAll();
    }
}

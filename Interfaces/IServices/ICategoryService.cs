using Catalog.DTO;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<CategoryDTO> UpdateTable(CategoryDTO obj);
        Task<CategoryDTO> GetTableByID(int? id);
        Task<Category> DeleteTable(int id);
        Task<Category> AddTable(CategoryDTO obj);
        Task<IEnumerable<CategoryDTO>> GetAll();
    }
}

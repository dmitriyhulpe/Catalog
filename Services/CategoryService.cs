using AutoMapper;
using Catalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catalog.DTO;
using Catalog.Models;
using Catalog.Interfaces.IUnitOfWork;
using Catalog.Interfaces.IServices;

namespace Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uof;
        protected IMapper _mapper;
        public CategoryService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;

        }

        public async Task<Category> AddTable(CategoryDTO obj)
        {
            Category loc = _mapper.Map<CategoryDTO, Category>(obj);
            var res = await _uof.Category.Add(loc);
            await _uof.Complete();
            return res;
        }

        public async Task<Category> DeleteTable(int id)
        {
            var res = await _uof.Category.Delete(id);
            await _uof.Complete();
            return res;
        }
        public async Task<CategoryDTO> GetTableByID(int? id)
        {
            var res = _mapper.Map<Category, CategoryDTO>(await _uof.Category.GetById(id.Value));
            return res;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var res = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(await _uof.Category.Get());
            return res;
        }

        public async Task<CategoryDTO> UpdateTable(CategoryDTO obj)
        {
            Category location = _mapper.Map<Category>(obj);
            var res = _mapper.Map<Category, CategoryDTO>(await _uof.Category.Update(location));
            await _uof.Complete();
            return res;

        }
    }
}

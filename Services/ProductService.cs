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

namespace project.BuisnessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uof;
        protected IMapper _mapper;
        public ProductService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public async Task<Product> AddTable(ProductDTO obj)
        {
            Product loc = _mapper.Map<ProductDTO, Product>(obj);
            var res = await _uof.Product.Add(loc);
            await _uof.Complete();
            return res;
        }

        public async Task<Product> DeleteTable(int id)
        {
            var res = await _uof.Product.Delete(id);
            await _uof.Complete();
            return res;
        }
        public async Task<ProductDTO> GetTableByID(int? id)
        {
            var res = _mapper.Map<Product, ProductDTO>(await _uof.Product.GetById(id.Value));
            return res;
        }
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var res = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await _uof.Product.Get());
            return res;
        }

        public async Task<ProductDTO> UpdateTable(ProductDTO obj)
        {
            Product location = _mapper.Map<Product>(obj);
            var res = _mapper.Map<Product, ProductDTO>(await _uof.Product.Update(location));
            await _uof.Complete();
            return res;

        }
    }
}

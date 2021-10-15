using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restuarant.Services.ProductAPI.DbContexts;
using Restuarant.Services.ProductAPI.Models;
using Restuarant.Services.ProductAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restuarant.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDBContext db, IMapper mapper )
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                //Update
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product,ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try {
                Product product = await _db.Products.Where(a => a.ProductId == productId).FirstOrDefaultAsync();
                if (product == null)
                    return false;
                else
                {
                    _db.Products.Remove(product);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }
            catch { return false; }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(a => a.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);    
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
           List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);

        }
    }
}

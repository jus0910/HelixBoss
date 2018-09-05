using HelixBoss.Interfaces;
using HelixBoss.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelixBoss.ApiService
{
    public class ProductService : IProductService<Product>
    {
        private ProductContext _context;
        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            Product result = null;
            result = _context.Products.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            List<Product> products = null;
            products = _context.Products.ToList();

            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            Product result = null;
            result = _context.Products.SingleOrDefault(p => p.Id == id);
            
            return result;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var local = _context.Set<Product>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

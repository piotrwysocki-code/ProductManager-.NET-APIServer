using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{
    public class ProductRepository : IProductRepo
    {
        private Site_DBContext _dbContext;

        public ProductRepository(Site_DBContext ctext)
        {
            _dbContext = ctext;            
        }
        public IQueryable<Product> Products => _dbContext.Products;

        public Product this[int id] => (Product)Products.Where(x => x.ProductId == id).FirstOrDefault() != null ? (Product)Products.Where(x => x.ProductId == id).FirstOrDefault() : null;

        public Product AddProduct(Product product)
        {
            Product temp = Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            if(temp != null)
            {
                RemoveProduct(temp.ProductId);
                _dbContext.Products.Add(product);
            }
            else
            {
                _dbContext.Products.Add(product);
            }

            _dbContext.SaveChanges();

            return product;            
        }

        public void RemoveProduct(int id)
        {
            Product p = (Product)_dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
            _dbContext.Products.Remove(p);
            _dbContext.SaveChanges();
        }

        public Product UpdateProduct(Product product)
        {
            AddProduct(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

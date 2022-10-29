using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

            if (product.ProductId != null && !product.ProductId.Equals("")
                && product.ProductName != null && !product.ProductName.Equals("")
                && product.Price != null && !product.Price.Equals("")
                && product.CategoryId != null && !product.CategoryId.Equals(""))
            {
                try
                {
                    Product temp = Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                    if (temp != null)
                    {
                        RemoveProduct(temp.ProductId);
                        _dbContext.Products.Add(product);
                    }
                    else
                    {
                        int maxId = (_dbContext.Products.Select(x => (int?)x.ProductId).Max() ?? 0) + 1;
                        product.ProductId = maxId;

                        _dbContext.Products.Add(product);
                    }

                    _dbContext.SaveChanges();

                    return product;
                }
                catch(DbUpdateException ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return null;
        }

        public void RemoveProduct(int id)
        {
            try
            {
                Product p = (Product)_dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
                _dbContext.Products.Remove(p);
                _dbContext.SaveChanges();
            }catch(DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }

        }

        public Product UpdateProduct(Product product)
        {
            try
            {
                AddProduct(product);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                return null;
            }

            return product;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{
    public interface IProductRepo
    {
        IQueryable<Product> Products { get; }

        Product this[int id] { get; }

        Product AddProduct(Product product);

        void RemoveProduct(int id);

        Product UpdateProduct(Product product);

        void saveDbChanges();

    }




}

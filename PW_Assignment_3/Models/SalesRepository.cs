using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{
    public class SalesRepository : ISalesRepo
    {
        private Site_DBContext _dbContext;

        public SalesRepository(Site_DBContext ctext)
        {
            _dbContext = ctext;            
        }
        public IQueryable<Sale> Sales => _dbContext.Sales;

        public Sale this[int id] => (Sale)Sales.Where(x => x.SaleId == id).FirstOrDefault() != null ? (Sale)Sales.Where(x => x.SaleId == id).FirstOrDefault() : null;

        public Sale AddSale(Sale sale)
        {

            if (sale.SaleId != null && !sale.SaleId.Equals("")
                && sale.SaleId != null && !sale.SaleId.Equals("")
                && sale.SaleDate != null && !sale.SaleDate.Equals("")
                && sale.Total != null && !sale.Total.Equals("")
                && sale.EmployeeId != null && !sale.EmployeeId.Equals(""))

            {
                try
                {
                    Sale temp = Sales.Where(x => x.SaleId == sale.SaleId).FirstOrDefault();

                    if (temp != null)
                    {
                        RemoveSale(temp.SaleId);
                        _dbContext.Sales.Add(sale);
                    }
                    else
                    {
                        int maxId = (_dbContext.Sales.Select(x => (int?)x.SaleId).Max() ?? 0) + 1;

                        sale.SaleId = maxId;

                        _dbContext.Sales.Add(sale);
                    }

                    _dbContext.SaveChanges();

                }
                catch
                {
                    Console.WriteLine("error");
                }
                return sale;

            }

            return null;
        }

        public void RemoveSale(int id)
        {
            try
            {
                Sale p = (Sale)_dbContext.Sales.Where(x => x.SaleId == id).FirstOrDefault();
                _dbContext.Sales.Remove(p);
                _dbContext.SaveChanges();
            }catch(DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }

        }

        public Sale UpdateSale(Sale sale)
        {
            AddSale(sale);
            _dbContext.SaveChanges();
            return sale;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

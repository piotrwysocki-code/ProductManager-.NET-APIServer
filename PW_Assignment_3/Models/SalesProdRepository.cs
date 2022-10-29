using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{
    public class SalesProdRepository : ISalesProdRepo
    {
        private Site_DBContext _dbContext;

        public SalesProdRepository(Site_DBContext ctext)
        {
            _dbContext = ctext;
        }
        public IQueryable<SalesProd> SalesProds => _dbContext.SalesProds;

        public IQueryable<SalesProd> this[int id] => SalesProds.Where(x => x.SaleId == id) != null ? SalesProds.Where(x => x.SaleId == id) : null;

        public SalesProd getSalesProd(int id, int id2)
        {
            var temp = (SalesProd)SalesProds.Where(x => x.SaleId == id && x.ProductId == id2).FirstOrDefault() != null ? (SalesProd)SalesProds.Where(x => x.SaleId == id && x.ProductId == id2).FirstOrDefault() : null;
            
            return temp;
        }

        public SalesProd AddSalesProd(SalesProd sale)
        {
            if (sale.SaleId != null && sale.SaleId != 0
                && sale.ProductId != null && sale.ProductId != 0
                && sale.Quantity != null && sale.Quantity != 0)
            {
                try
                {
                    SalesProd temp = SalesProds.Where(x => x.SaleId == sale.SaleId && x.ProductId == sale.ProductId).FirstOrDefault();
                    if (temp != null)
                    {
                        RemoveSalesProd(temp.SaleId, temp.ProductId);
                        _dbContext.SalesProds.Add(sale);
                    }
                    else
                    {
                        _dbContext.SalesProds.Add(sale);
                    }

                    _dbContext.SaveChanges();

                    return sale;

                }
                catch
                {
                    Console.WriteLine("error");
                }
            }

            return null;

        }

        public bool RemoveSalesProd(int id, int id2)
        {

            SalesProd p = (SalesProd)SalesProds.Where(x => x.SaleId == id && x.ProductId == id2).FirstOrDefault();
            try
            {
                if (p != null)
                {
                    _dbContext.SalesProds.Remove(p);
                    _dbContext.SaveChanges();

                    return true;

                }
            }catch(DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }

          
             return false;
            
        }

        public SalesProd UpdateSalesProd(SalesProd prods)
        {
            SalesProd newSale = prods;


            RemoveSalesProd(newSale.SaleId, newSale.ProductId);
            AddSalesProd(newSale);

            _dbContext.SaveChanges();

            return newSale;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

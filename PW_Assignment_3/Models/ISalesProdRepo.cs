using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{

    public interface ISalesProdRepo
    {
        IQueryable<SalesProd> SalesProds { get; }

        IQueryable<SalesProd> this[int id] { get; }

        SalesProd AddSalesProd(SalesProd salesprod);

        bool RemoveSalesProd(int id, int id2);

        SalesProd getSalesProd(int id, int id2);

        SalesProd UpdateSalesProd(SalesProd salesprod);

        public void saveDbChanges();
    }
}

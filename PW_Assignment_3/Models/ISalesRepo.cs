using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{

    public interface ISalesRepo
    {
        IQueryable<Sale> Sales { get; }

        Sale this[int id] { get; }

        Sale AddSale(Sale sale);

        void RemoveSale(int id);

        Sale UpdateSale(Sale sale);

        public void saveDbChanges();
    }
}

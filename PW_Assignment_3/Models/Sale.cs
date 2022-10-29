using System;
using System.Collections.Generic;

#nullable disable

namespace PW_Assignment_3.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public DateTime? SaleDate { get; set; }
        public double Total { get; set; }
        public int EmployeeId { get; set; }

    }
}

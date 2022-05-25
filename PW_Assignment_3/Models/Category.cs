using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PW_Assignment_3
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        [Column(TypeName = "int")]
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

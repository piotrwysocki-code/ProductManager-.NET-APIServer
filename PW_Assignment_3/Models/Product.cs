using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PW_Assignment_3
{
    public partial class Product
    {
        [Required]
        [Column(TypeName = "int")]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "float")]
        public decimal? Price { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}

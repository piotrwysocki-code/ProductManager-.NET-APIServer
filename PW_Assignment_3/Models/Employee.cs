using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PW_Assignment_3.Models
{
    public class Employee
    {
        // [Required]
        [Column(TypeName = "int")]
        public int employeeId { get; set; }
        // [Required]
        [Column(TypeName = "int")]
        public int deptId { get; set; }
        //[Required]
        [Column(TypeName = "varchar(255)")]
        public string lastName { get; set; }
        //[Required]
        //[Required]
        [Column(TypeName = "varchar(255)")]
        public string firstName { get; set; }
        //[Required]
        [Column(TypeName = "float")]
        public decimal salary { get; set; }

        //[Required]
        [Column(TypeName = "varchar(255)")]
        public string city { get; set; }

        //[Required]
        [Column(TypeName = "varchar(255)")]
        public string province { get; set; }


    }
}


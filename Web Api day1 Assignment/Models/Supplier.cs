﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_day1_Assignment.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        // Navigation properties.
        // Child.
        public virtual ICollection<ProduceSupplier>
            ProduceSuppliers
        { get; set; }
    }
}

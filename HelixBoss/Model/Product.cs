using HelixBoss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelixBoss.Model
{
    public class Product : AbstractEntity<int>, IAuditable
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double SaleAmount { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set;  }
        public DateTime ModifiedDate { get; set;  }
        public string ModifiedBy { get; set;  }
    }
}

using HelixBoss.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelixBoss.BusinessEntity
{
    public class ProductBE<T> : ITransaction
    {
        public ProductBE()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public T[] Product { get; set; }
    }
}

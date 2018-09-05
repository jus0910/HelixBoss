using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelixBoss.Interfaces
{
    public class AbstractEntity<T>
    {
        public T Id { get; set; }
    }
}

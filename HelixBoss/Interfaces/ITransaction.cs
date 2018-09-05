using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelixBoss.Interfaces
{
    interface ITransaction
    {
        Guid Id { get; set; }
        DateTime Timestamp { get; set; }
    }
}

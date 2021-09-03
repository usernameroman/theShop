using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Services.Interfaces
{
    public interface ISupplierManager
    {
        IList<ISupplierService> SupplierServices { get; }
    }
}

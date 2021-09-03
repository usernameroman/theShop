using System.Collections.Generic;
using TheShop.Services.Interfaces;
using TheShop.Services.Suppliers;

namespace TheShop.Services
{
    public class SupplierManager : ISupplierManager
    {
        public IList<ISupplierService> SupplierServices { get; }

        public SupplierManager()
        {
            SupplierServices = new List<ISupplierService>() {
                new SupplierService1(),
                new SupplierService2(),
                new SupplierService3()
            };

        }

    }
}

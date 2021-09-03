using TheShop.Domain;
using TheShop.Services.Interfaces;

namespace TheShop.Services.Suppliers
{
	// we assume that this service is black box
    public class SupplierService1 : ISupplierService
    {
		public bool HasArticle(int id)
		{
			return true;
		}

		public virtual Article GetArticleById(int id)
		{
			return new Article()
			{
				Id = 1,
				Name = "Article from supplier1",
				Price = 10
			};
		}
	}
}

using TheShop.Domain;
using TheShop.Services.Interfaces;

namespace TheShop.Services.Suppliers
{
	// we assume that this service is black box
	public class SupplierService2: ISupplierService
    {
		public bool HasArticle(int id)
		{
			return true;
		}

		public Article GetArticleById(int id)
		{
			return new Article()
			{
				Id = 1,
				Name = "Article from supplier2",
				Price = 459
			};
		}
	}
}

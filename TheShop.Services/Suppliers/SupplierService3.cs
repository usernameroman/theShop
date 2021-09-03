using TheShop.Domain;
using TheShop.Services.Interfaces;

namespace TheShop.Services.Suppliers
{
	public class SupplierService3 : ISupplierService
	{
		public bool ArticleInInventory(int id)
		{
			return true;
		}

		public Article GetArticle(int id)
		{
			return new Article()
			{
				Id = 1,
				Name = "Article from supplier3",
				Price = 460
			};
		}
	}
}

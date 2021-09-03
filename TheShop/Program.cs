using System;
using TheShop.Repository;
using TheShop.Services;
using TheShop.Services.Suppliers;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var shopService = new ShopService(new ArticleRepository(), new LoggerService());

			shopService.AddSupplier(new SupplierService1());
			shopService.AddSupplier(new SupplierService2());
			shopService.AddSupplier(new SupplierService3());

			try
			{
				//order and sell
				shopService.OrderAndSellArticle(1, 20, 10);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				//print article on console
				var article = shopService.GetById(1);
				Console.WriteLine("Found article with ID: " + article.Id);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = shopService.GetById(12);
				Console.WriteLine("Found article with ID: " + article.Id);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			Console.ReadKey();
		}
	}
}
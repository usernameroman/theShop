using System;
using TheShop.Repository;
using TheShop.Services;

namespace TheShop
{
    internal class Program
	{
		private static void Main(string[] args)
		{
			var articleRepository = new ArticleRepository();

			var articleService = new ArticleService(articleRepository);
			var shopService = new ShopService(articleRepository, new LoggerService(), new SupplierManager());

			try
			{
				//order and sell
				var article = shopService.OrderArticle(1, 20);
				shopService.SellArticle(10, article);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			try
			{
				//print article on console
				var article = articleService.GetById(1);
				Console.WriteLine($"Found article with ID: {article.Id}");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = articleService.GetById(12);
				Console.WriteLine($"Found article with ID: {article.Id}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Article not found: {ex.Message}");
			}

			Console.ReadKey();
		}
	}
}
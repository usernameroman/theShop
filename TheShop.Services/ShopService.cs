using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Domain;
using TheShop.Repository.Interfaces;
using TheShop.Services.Interfaces;

namespace TheShop
{
	public class ShopService
	{
		private readonly IArticleRepository _articleRepository;
		private readonly ILoggerService _logger;

		private readonly List<ISupplierService> _suppliers = new List<ISupplierService>();
		
		public ShopService(IArticleRepository articleRepository, ILoggerService loggerService)
		{
			_articleRepository = articleRepository;
			_logger = loggerService;
		}

		public void AddSupplier(ISupplierService supplier)
        {
			_suppliers.Add(supplier);
        }

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
            #region ordering article

            Article article = null;

			foreach (var supplier in _suppliers)
            {
				if (!supplier.HasArticle(id))
                {
					continue;
                }

				var tempArticle = supplier.GetArticleById(id);
				if (tempArticle.Price > maxExpectedPrice)
                {
					continue;
                } 
				else
                {
					article = tempArticle;
                }
            }
            /*if (articleExists)
            {
                tempArticle = Supplier1.GetArticle(id);
                if (maxExpectedPrice < tempArticle.ArticlePrice)
                {
                    articleExists = Supplier2.ArticleInInventory(id);
                    if (articleExists)
                    {
                        tempArticle = Supplier2.GetArticle(id);
                        if (maxExpectedPrice < tempArticle.ArticlePrice)
                        {
                            articleExists = Supplier3.ArticleInInventory(id);
                            if (articleExists)
                            {
                                tempArticle = Supplier3.GetArticle(id);
                                if (maxExpectedPrice < tempArticle.ArticlePrice)
                                {
                                    article = tempArticle;
                                }
                            }
                        }
                    }
                }
            }*/
			#endregion

			#region selling article

			if (article == null)
			{
				throw new Exception("Could not order article");
			}

			_logger.Debug("Trying to sell article with id=" + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;
			
			try
			{
				_articleRepository.Add(article);
				_logger.Info("Article with id=" + id + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				_logger.Error("Could not save article with id=" + id);
				throw new Exception("Could not save article with id");
			}
			catch (Exception)
			{
			}

			#endregion
		}

		public Article GetById(int id)
		{
			return _articleRepository.GetById(id);
		}
	}	
}

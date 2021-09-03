using System;
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
        private readonly ISupplierManager _supplierManager;

        public ShopService(IArticleRepository articleRepository, ILoggerService loggerService, ISupplierManager supplierManager)
        {
            _articleRepository = articleRepository;
            _logger = loggerService;
            _supplierManager = supplierManager;
        }

        public Article OrderArticle(int id, int maxExpectedPrice)
        {
            return _supplierManager.SupplierServices
                .FirstOrDefault(x => x.HasArticle(id) && x.GetArticleById(id).Price < maxExpectedPrice)
                ?.GetArticleById(id);
        }

        public void SellArticle(int buyerId, Article article)
        {
            if (article == null)
            {
                throw new ArgumentException("Article can not be null");
            }

            _logger.Debug($"Trying to sell article with id={article.Id}");

            article.IsSold = true;
            article.SoldDate = DateTime.UtcNow;
            article.BuyerId = buyerId;

            _articleRepository.Add(article);
            _logger.Info($"Article with id={article.Id} is sold.");
        }
    }
}

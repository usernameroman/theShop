using TheShop.Domain;
using TheShop.Repository.Interfaces;

namespace TheShop.Services
{
    public class ArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Article GetById(int id)
        {
            return _articleRepository.GetById(id);
        }
    }
}

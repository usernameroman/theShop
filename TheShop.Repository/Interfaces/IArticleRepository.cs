using TheShop.Domain;

namespace TheShop.Repository.Interfaces
{
    public interface IArticleRepository
    {
        Article GetById(int id);

        void Save(Article article);
    }
}

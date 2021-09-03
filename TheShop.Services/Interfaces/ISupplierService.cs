using TheShop.Domain;

namespace TheShop.Services.Interfaces
{
    public interface ISupplierService
    {
        bool HasArticle(int id);

        Article GetArticleById(int id);
    }
}

using TheShop.Domain;

namespace TheShop.Services.Interfaces
{
    public interface ISupplierService
    {
        bool ArticleInInventory(int id);

        Article GetArticle(int id);
    }
}

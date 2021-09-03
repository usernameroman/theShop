using System.Collections.Generic;
using System.Linq;
using TheShop.Domain;

namespace TheShop.Repository
{
    public class ArticleRepository
    {
		private readonly List<Article> _articles = new List<Article>();

		public Article GetById(int id)
		{
			return _articles.Single(x => x.Id == id);
		}

		public void Save(Article article)
		{
			_articles.Add(article);
		}
	}
}

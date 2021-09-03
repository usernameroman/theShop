using System.Collections.Generic;
using System.Linq;
using TheShop.Domain;
using TheShop.Repository.Interfaces;

namespace TheShop.Repository
{
    public class ArticleRepository: IArticleRepository
	{
		private readonly IList<Article> _articles = new List<Article>();

		public Article GetById(int id)
		{
			return _articles.Single(x => x.Id == id);
		}

		public void Add(Article article)
		{
			_articles.Add(article);
		}
	}
}

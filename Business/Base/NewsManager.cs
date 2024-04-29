using Business.Abstract;
using DataAccess.Abstract.Repository;
using Shared.Dtos;
using Shared.Entities;

namespace Business.Base
{
    public class NewsManager : INewsService
    {
        private readonly IRepository<News> _repository;
		private readonly IRepository<Writer> _repositoryWriter;
		private readonly IRepository<Category> _repositoryCategory;

		public NewsManager(IRepository<News> repository, IRepository<Writer> repositoryWriter, IRepository<Category> repositoryCategory)
        {
            _repository = repository;
            _repositoryWriter = repositoryWriter;
            _repositoryCategory = repositoryCategory;
        }

        public NewsDto Add(NewsDto model)
        {
            model.NewsDate = DateTime.Now;
            News response = _repository.Add(NewsItem(model));
            
            return NewsItem(response);
        }

        public NewsDto Update(NewsDto model)
        {
            var news = _repository.GetById(model.NewsId);
            news.NewsId = model.NewsId;
            news.Title = model.Title;
            news.Contents = model.Contents;
            news.ClicksNumber = model.ClicksNumber;
            news.Video = model.Video;
            news.WriterId = model.WriterId;
            news.CategoryId = model.CategoryId;
            news.NewsStatus = model.NewsStatus;

            News response = _repository.Update(news);

            return NewsItem(response);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(new News { NewsId = id });
        }

        public List<NewsDto> GetAll()
        {
            var response = _repository.GetAll().ToList();
            List<NewsDto> result = new List<NewsDto>();
            
            foreach (var item in response)
            {
                result.Add(NewsItem(item));    
            }            
            return result;
        }

        public NewsDto GetById(int id)
        {
            var response = _repository.GetById(id);
            return NewsItem(response);
        }             

        private News NewsItem(NewsDto model)
        {
            News result = new News();
            result.NewsId = model.NewsId;
            result.Title = model.Title;
            result.Contents = model.Contents;
            result.NewsDate = model.NewsDate;
            result.ClicksNumber = model.ClicksNumber;
            result.Image = model.Image;
            result.Video = model.Video;
            result.WriterId = model.WriterId;
            result.CategoryId = model.CategoryId;
            result.NewsStatus = model.NewsStatus;

            return result;
        }

        private NewsDto NewsItem(News model)
        {
            var writer = _repositoryWriter.GetById(model.WriterId);
            var category = _repositoryCategory.GetById(model.CategoryId);
            string writerFullName = writer.Name + " " + writer.SurName;

			NewsDto result = new NewsDto();
            result.NewsId = model.NewsId;
            result.Title = model.Title;
            result.Contents = model.Contents;
            result.NewsDate = model.NewsDate;
            result.ClicksNumber = model.ClicksNumber;
            result.Image = model.Image;
            result.Video = model.Video;
            result.WriterId = model.WriterId;
            result.CategoryId = model.CategoryId;
            result.NewsStatus = model.NewsStatus;

			result.Writer = writerFullName;
            result.WriterImage = writer.Image;
            result.Category = category.CategoryName;

			return result;
        }
    }
}

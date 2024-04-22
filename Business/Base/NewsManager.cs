using Business.Abstract;
using DataAccess.Abstract.Repository;
using Shared.Dtos;
using Shared.Entities;

namespace Business.Base
{
    public class NewsManager : INewsService
    {
        private readonly IRepository<News> _repository;

        public NewsManager(IRepository<News> repository)
        {
            _repository = repository;
        }

        public NewsDto Add(NewsDto model)
        {
            var response = _repository.Add(NewsItem(model));
            
            return NewsItem(response);
        }

        public NewsDto Update(NewsDto model)
        {
            var news = _repository.GetById(model.NewsId);
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

            return result;
        }
    }
}

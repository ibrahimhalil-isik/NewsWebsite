using Business.Abstract;
using DataAccess.Abstract.Repository;
using Shared.Dtos;
using Shared.Entities;

namespace Business.Base
{
    public class SlideManager : ISlideService
    {
        private readonly IRepository<Slide> _repository;
        public SlideManager(IRepository<Slide> repository)
        {
            _repository = repository;
        }

        public SlideDto Add(SlideDto model)
        {
            var response = _repository.Add(SlideItem(model));
            return SlideItem(response);
        }

        public SlideDto Update(SlideDto model)
        {
            var slide = _repository.GetById(model.SlideId);
            Slide response = _repository.Update(slide);

            return SlideItem(response);
        }
        public bool Delete(int id)
        {
            return _repository.Delete(new Slide { SlideId = id});
        }

        public List<SlideDto> GetAll()
        {
            var response = _repository.GetAll().ToList();
            List<SlideDto> result = new List<SlideDto>();

            foreach (var item in response)
            {
                result.Add(SlideItem(item));
            }
            return result;
        }

        public SlideDto GetById(int id)
        {
            var response = _repository.GetById(id);
            return SlideItem(response);
        }

        private Slide SlideItem (SlideDto model)
        {
            Slide result = new Slide();
            result.SlideId = model.SlideId;
            result.Title = model.Title;
            result.Content = model.Content;
            result.NewsId = model.NewsId;
            result.Image = model.Image;
            result.SlideStatus = model.SlideStatus;

            return result;
        }

        private SlideDto SlideItem (Slide model)
        {
            SlideDto result = new SlideDto();
            result.SlideId = model.SlideId;
            result.Title = model.Title;
            result.Content = model.Content;
            result.NewsId = model.NewsId;
            result.Image = model.Image;
            result.SlideStatus = model.SlideStatus;

            return result;
        }
    }
}

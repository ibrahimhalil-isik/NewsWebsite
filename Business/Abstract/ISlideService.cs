using Shared.Dtos;

namespace Business.Abstract
{
    public interface ISlideService
    {
        List<SlideDto> GetAll();
        SlideDto GetById(int id);
        SlideDto Add(SlideDto model);
        SlideDto Update(SlideDto model);
        bool Delete(int id);
    }
}

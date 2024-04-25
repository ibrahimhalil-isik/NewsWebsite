using Shared.Dtos;

namespace ApiAccess.Abstract
{
    public interface ISlideApiRequest
    {
        List<SlideDto> GetAll();
        SlideDto GetById(int id);
        SlideDto Add(SlideDto model);
        SlideDto Update(SlideDto model);
        bool Delete(int id);
    }
}

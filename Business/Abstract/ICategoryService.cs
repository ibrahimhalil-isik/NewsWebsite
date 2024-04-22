using Shared.Dtos;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        CategoryDto Add(CategoryDto model);
        CategoryDto Update(CategoryDto model);
        bool Delete(int id);
    }
}

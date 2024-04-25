using Shared.Dtos;

namespace ApiAccess.Abstract
{
    public interface ICategoryApiRequest
    {
        List<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        CategoryDto Add(CategoryDto model);
        CategoryDto Update(CategoryDto model);
        bool Delete(int id);
    }
}

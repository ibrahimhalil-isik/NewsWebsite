using Business.Abstract;
using DataAccess.Abstract.Repository;
using Shared.Dtos;
using Shared.Entities;

namespace Business.Base
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        public CategoryManager(IRepository<Category> repository)
        {
            _repository = repository;   
        }
        public CategoryDto Add(CategoryDto model)
        {
            var response = _repository.Add(CategoryItem(model));

            return CategoryItem(response);
        }
        public CategoryDto Update(CategoryDto model)
        {
            var category = _repository.GetById(model.CategoryId);
			category.CategoryStatus= model.CategoryStatus;
			category.CategoryName = model.CategoryName;
			Category response = _repository.Update(category);

            return CategoryItem(response);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(new Category { CategoryId = id });
        }

        public List<CategoryDto> GetAll()
        {
            var response = _repository.GetAll().ToList();
            List<CategoryDto> result = new List<CategoryDto>();

            foreach (var item in response)
            {
                result.Add(CategoryItem(item));
            }
            return result;
        }

        public CategoryDto GetById(int id)
        {
            var response = _repository.GetById(id);
            return CategoryItem(response);
        }

        private Category CategoryItem(CategoryDto model)
        {
            Category result = new Category();
            result.CategoryId = model.CategoryId;
            result.CategoryName = model.CategoryName;
            result.CategoryStatus = model.CategoryStatus;

            return result;
        }
        private CategoryDto CategoryItem(Category model)
        {
            CategoryDto result = new CategoryDto();
            result.CategoryId = model.CategoryId;
            result.CategoryName = model.CategoryName;
            result.CategoryStatus = model.CategoryStatus;

            return result;
        }
    }
}
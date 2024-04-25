using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace ApiUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public List<CategoryDto> GetAll() => _categoryService.GetAll();

        [HttpGet]
        [Route("GetCategoryById")]
        public CategoryDto GetById(int id) => _categoryService.GetById(id);

        [HttpGet]
        [Route("DeleteCategory")]
        public bool Delete(int id) => _categoryService.Delete(id);

        [HttpPost]
        [Route("AddCategory")]
        public CategoryDto Add(CategoryDto model) => _categoryService.Add(model);

        [HttpPost]
        [Route("UpdateCategory")]
        public CategoryDto Update(CategoryDto model) => _categoryService.Update(model);
    }
}

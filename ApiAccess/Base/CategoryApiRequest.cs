using ApiAccess.Abstract;
using Shared.Dtos;
using Shared.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAccess.Base
{
    public class CategoryApiRequest : ICategoryApiRequest
    {
        private readonly IRequestService _requestService;
        public CategoryApiRequest(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public List<CategoryDto> GetAll() 
            => _requestService.Get<List<CategoryDto>>("/Category/GetAllCategory");

        public CategoryDto GetById(int id) 
            => _requestService.Get<CategoryDto>("/Category/GetCategoryById?id=" + id);

        public CategoryDto Add(CategoryDto model) 
            => _requestService.Post<CategoryDto>("/Category/AddCategory", model);

        public CategoryDto Update(CategoryDto model) 
            => _requestService.Post<CategoryDto>("/Category/UpdateCategory", model);

        public bool Delete(int id) 
            => _requestService.Get<bool>("/Category/DeleteCategory?id=" + id);
    }
}

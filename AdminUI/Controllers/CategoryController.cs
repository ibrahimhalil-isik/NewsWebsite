using AdminUI.Models;
using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace AdminUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryApiRequest _categoryApiRequest;
		public CategoryController(ICategoryApiRequest categoryApiRequest)
		{
			_categoryApiRequest = categoryApiRequest;
		}
		public IActionResult Index()
		{
			var pageData = _categoryApiRequest.GetAll();
			return View(pageData);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCategory(CategoryViewModel model)
		{
			CategoryDto category = new CategoryDto()
			{
				CategoryStatus = model.CategoryStatus,
				CategoryName = model.CategoryName
			};
			var result = _categoryApiRequest.Add(category);

			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			var data = _categoryApiRequest.GetById(id);

			CategoryViewModel category = new CategoryViewModel()
			{
				CategoryId = data.CategoryId,
				CategoryStatus = data.CategoryStatus,
				CategoryName = data.CategoryName
			};
			return View(category);
		}

		[HttpPost]
		public IActionResult UpdateCategory(CategoryViewModel model)
		{
			CategoryDto category = new CategoryDto()
			{
				CategoryId = model.CategoryId.Value,
				CategoryStatus = model.CategoryStatus,
				CategoryName = model.CategoryName
			};
			_categoryApiRequest.Update(category);
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			_categoryApiRequest.Delete(id);
			return RedirectToAction("Index");
		}
	}
}

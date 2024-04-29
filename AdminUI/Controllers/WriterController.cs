using AdminUI.Models;
using ApiAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace AdminUI.Controllers
{
	public class WriterController : Controller
	{
		private readonly IWriterApiRequest _writerApiRequest;
		private readonly ICommonApiRequest _commonApiRequest;
		public WriterController(IWriterApiRequest writerApiRequest, ICommonApiRequest commonApiRequest)
		{
			_writerApiRequest = writerApiRequest;
			_commonApiRequest = commonApiRequest;
		}
        public IActionResult Index() => View(_writerApiRequest.GetAll());

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddWriter(WriterViewModel model)
		{
            var imageUrl = _commonApiRequest.Upload(model.ImageFile);

            WriterDto writer = new WriterDto()
			{
				Name = model.Name,
				SurName = model.SurName,
				Email = model.Email,
				Password = model.Password,
				WriterStatus = model.WriterStatus,
				Image = imageUrl,
			};
			var result = _writerApiRequest.Add(writer);

			return RedirectToAction("Index", "Writer");
		}

		public IActionResult Update(int id)
		{
			var model = _writerApiRequest.GetById(id);

			WriterViewModel writer = new WriterViewModel()
			{
				WriterId = model.WriterId,
				Name = model.Name,
				SurName = model.SurName,
				Image = model.Image,
				Email = model.Email,
				Password = model.Password,
				WriterStatus = model.WriterStatus,
			};
			return View(writer);
		}

		[HttpPost]
		public IActionResult UpdateWriter(WriterViewModel model)
		{
            string imageUrl = model.Image;
            if (model.ImageFile != null)
            {
                imageUrl = _commonApiRequest.Upload(model.ImageFile);
            }

            WriterDto writer = new WriterDto()
			{
				WriterId = model.WriterId,
				Name = model.Name,
				SurName = model.SurName,
				Image = imageUrl,
				Email = model.Email,
				Password = model.Password,
				WriterStatus = model.WriterStatus,
			};
			_writerApiRequest.Update(writer);
			return RedirectToAction("Index", "Writer");
		}

		public IActionResult Delete(int id)
		{
			_writerApiRequest.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
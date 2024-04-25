using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace ApiUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        [Route("GetAllWrite")]
        public List<WriterDto> GetAll() => _writerService.GetAll();

        [HttpGet]
        [Route("GetWriterById")]
        public WriterDto GetById(int id) => _writerService.GetById(id);

        [HttpGet]
        [Route("GetWriterByEmailPassword")]
        public WriterDto GetEmailAndPassword(string email, string password) => _writerService.GetWriterByEmailPassword(email, password);

        [HttpGet]
        [Route("DeleteWriter")]
        public bool Delete(int id) => _writerService.Delete(id);

        [HttpPost]
        [Route("AddWriter")]
        public WriterDto Add(WriterDto model) => _writerService.Add(model);

        [HttpPost]
        [Route("UpdateWriter")]
        public WriterDto Update(WriterDto model) => _writerService.Update(model);
    }
}

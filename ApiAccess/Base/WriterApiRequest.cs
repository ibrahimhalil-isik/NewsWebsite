using ApiAccess.Abstract;
using Shared.Dtos;
using Shared.Helpers.Abstract;

namespace ApiAccess.Base
{
	public class WriterApiRequest : IWriterApiRequest
	{
		private readonly IRequestService _requestService;
		public WriterApiRequest(IRequestService requestService)
		{
			_requestService = requestService;
		}

		public List<WriterDto> GetAll()
			=> _requestService.Get<List<WriterDto>>("Writer/GetAllWrite");

		public WriterDto GetById(int id)
			=> _requestService.Get<WriterDto>("Writer/GetWriterById" + id);

		public WriterDto GetWriterByEmailPassword(string email, string password)
		{
			return _requestService.Get<WriterDto>("Writer/GetWriterByEmailPassword?email=" + email + "&password=" + password);
		}

		public WriterDto Add(WriterDto model)
			=> _requestService.Post<WriterDto>("Writer/DeleteWriter", model);

		public WriterDto Update(WriterDto model)
			=> _requestService.Post<WriterDto>("Writer/AddWriter", model);

		public bool Delete(int id)
			=> _requestService.Get<bool>("Writer/UpdateWriter" + id);
	}
}

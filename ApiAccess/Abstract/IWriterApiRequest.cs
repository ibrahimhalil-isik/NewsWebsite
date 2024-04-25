using Shared.Dtos;

namespace ApiAccess.Abstract
{
    public interface IWriterApiRequest
    {
        List<WriterDto> GetAll();
        WriterDto GetById(int id);
        WriterDto GetWriterByEmailPassword(string email, string password);
        WriterDto Add(WriterDto model);
        WriterDto Update(WriterDto model);
        bool Delete(int id);
    }
}

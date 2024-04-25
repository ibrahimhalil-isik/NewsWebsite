using Business.Abstract;
using DataAccess.Abstract.Repository;
using Shared.Dtos;
using Shared.Entities;

namespace Business.Base
{
    public class WriterManager : IWriterService
    {
        private readonly IRepository<Writer> _repository;
        public WriterManager(IRepository<Writer> repository)
        {
            _repository = repository;
        }

        public WriterDto Add(WriterDto model)
        {
            var response = _repository.Add(WriterItem(model));
            return WriterItem(response);
        }
        public WriterDto Update(WriterDto model)
        {
            var writer = _repository.GetById(model.WriterId);
            Writer response = _repository.Update(writer);
            return WriterItem(response);
        }
        public bool Delete(int id)
        {
            return _repository.Delete(new Writer { WriterId = id });
        }

        public List<WriterDto> GetAll()
        {
            var response = _repository.GetAll().ToList();
            List<WriterDto> result = new List<WriterDto>();

            foreach (var item in response)
            {
                result.Add(WriterItem(item));
            }
            return result;
        }

        public WriterDto GetById(int id)
        {
            var response = _repository.GetById(id);
            return WriterItem(response);
        }

        private Writer WriterItem(WriterDto model)
        {
            Writer result = new Writer();
            result.WriterId = model.WriterId;
            result.Name = model.Name;
            result.SurName = model.SurName;
            result.Image = model.Image;
            result.Email = model.Email;
            result.Password = model.Password;
            result.WriterStatus = model.WriterStatus;

            return result;
        }
        private WriterDto WriterItem(Writer model)
        {
            WriterDto result = new WriterDto();
            result.WriterId = model.WriterId;
            result.Name = model.Name;
            result.SurName = model.SurName;
            result.Image = model.Image;
            result.Email = model.Email;
            result.Password = model.Password;
            result.WriterStatus = model.WriterStatus;

            return result;
        }

        public WriterDto GetWriterByEmailPassword(string email, string password)
        {
            var writer = _repository.GetAll();
            var findedData = writer.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (findedData != null)
            { 
                return WriterItem(findedData); 
            }
            else { return null; }
        }
    }
}

using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INewsService
    {
        List<NewsDto> GetAll();
        NewsDto GetById(int id);    
        NewsDto Add(NewsDto model);
        NewsDto Update(NewsDto model);
        bool Delete(int id);
    }
}

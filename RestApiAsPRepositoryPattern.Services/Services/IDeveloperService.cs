using System.Collections.Generic;
using System.Threading.Tasks;
using RestApiAsPRepositoryPattern.Domain.Entities;

namespace RestApiAsPRepositoryPattern.Services.Services
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAll();
        Task<Developer> GetById(int id);
        Task<Developer> GetByEmail(string email);
        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int id);
    }
}
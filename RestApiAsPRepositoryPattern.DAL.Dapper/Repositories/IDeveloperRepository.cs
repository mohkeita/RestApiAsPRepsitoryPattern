using System.Collections.Generic;
using System.Threading.Tasks;
using RestApiAsPRepositoryPattern.Domain.Entities;

namespace RestApiAsPRepositoryPattern.DAL.Dapper.Repositories
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllAsync();
        Task<Developer> GetByIdAsync(int id);
        Task<Developer> GetByEmailAsync(string email);
        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int id);
    }
}
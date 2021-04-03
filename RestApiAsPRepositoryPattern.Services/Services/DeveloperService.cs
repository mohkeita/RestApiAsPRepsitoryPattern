using System.Collections.Generic;
using System.Threading.Tasks;
using RestApiAsPRepositoryPattern.DAL.Dapper.Repositories;
using RestApiAsPRepositoryPattern.Domain.Entities;

namespace RestApiAsPRepositoryPattern.Services.Services
{
    public class DeveloperService :IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        
        public Task<IEnumerable<Developer>> GetAll()
        {
            return _developerRepository.GetAllAsync();
        }

        public Task<Developer> GetById(int id)
        {
            return _developerRepository.GetByIdAsync(id);
        }

        public Task<Developer> GetByEmail(string email)
        {
            return _developerRepository.GetByEmailAsync(email);
        }

        public void AddDeveloper(Developer developer)
        {
            _developerRepository.AddDeveloper(developer);
        }

        public void UpdateDeveloper(Developer developer)
        {
            _developerRepository.UpdateDeveloper(developer);
        }

        public void DeleteDeveloper(int id)
        {
            _developerRepository.DeleteDeveloper(id);
        }
    }
}
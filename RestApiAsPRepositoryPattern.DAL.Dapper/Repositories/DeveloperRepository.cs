using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using RestApiAsPRepositoryPattern.Domain.Entities;

namespace RestApiAsPRepositoryPattern.DAL.Dapper.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected readonly IConfiguration _config;

        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DeveloperDBConnection"));
            }
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT Id, DeveloperName, Email, GitHubUrl, ImageUrl, Department, JoinedDate FROM Developers;";
                    return await dbConnection.QueryAsync<Developer>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> GetByIdAsync(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developers WHERE Id = @id;";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Id=id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> GetByEmailAsync(string email)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developers WHERE Email = @Email;";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Email=email });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO Developers(DeveloperName, Email, GitHubUrl, ImageUrl, Department, JoinedDate) VALUES(@DeveloperName, @Email, @GitHubUrl, @ImageUrl, @Department, @JoinedDate);";
                    dbConnection.Execute(query, developer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void UpdateDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE Developers SET DeveloperName=@DeveloperName, Email=@Email, GitHubUrl=@GitHubUrl, ImageUrl=@ImageUrl, Department=@Department, JoinedDate=@JoinedDate;";
                    dbConnection.Execute(query, developer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDeveloper(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM Developers WHERE Id = @id;";
                    dbConnection.Execute(query, new {Id = id});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
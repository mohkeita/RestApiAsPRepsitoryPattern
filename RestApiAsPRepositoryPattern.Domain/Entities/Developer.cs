using System;

namespace RestApiAsPRepositoryPattern.Domain.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; }
        public string Email { get; set; }
        public string GitHubUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Department { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
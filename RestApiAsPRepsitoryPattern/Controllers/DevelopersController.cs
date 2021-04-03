using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiAsPRepositoryPattern.Domain.Entities;
using RestApiAsPRepositoryPattern.Services.Services;

namespace RestApiAsPRepsitoryPattern.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DevelopersController : ControllerBase
    {
        protected readonly IDeveloperService DeveloperService;

        public DevelopersController(IDeveloperService developerService)
        {
            DeveloperService = developerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var developer = await DeveloperService.GetAll();
            return Ok(developer);
        }
        
        [Route("{action}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var developer = await DeveloperService.GetById(id);
            return Ok(developer);
        }

        [Route("{action}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var developer = await DeveloperService.GetByEmail(email);
            return Ok(developer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            
            DeveloperService.AddDeveloper(developer);
            return CreatedAtAction(nameof(GetById), new {Id = developer.Id}, developer);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            DeveloperService.UpdateDeveloper(developer);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteDeveloper(int id)
        {
            DeveloperService.DeleteDeveloper(id);

            return Ok();
        }
        
        
    }
}
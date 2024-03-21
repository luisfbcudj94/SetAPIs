using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IOperations<Configuration> _operationService;

        public ConfigurationController(IOperations<Configuration> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Configuration>> GetAllAsync()
        {
            IEnumerable<Configuration> data = await _operationService.GetAll();

            return data;
        }
    }
}

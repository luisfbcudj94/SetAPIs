using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APITypeController : ControllerBase
    {
        private readonly IOperations<APIType> _operationService;

        public APITypeController(IOperations<APIType> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<APIType>> GetAllAsync()
        {
            IEnumerable<APIType> data = await _operationService.GetAll();

            return data;
        }
    }
}

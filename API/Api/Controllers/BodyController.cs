using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyController : ControllerBase
    {
        private readonly IOperations<Body> _operationService;

        public BodyController(IOperations<Body> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Body>> GetAllAsync()
        {
            IEnumerable<Body> data = await _operationService.GetAll();

            return data;
        }
    }
}

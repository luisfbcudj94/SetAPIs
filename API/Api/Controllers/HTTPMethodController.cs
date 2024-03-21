using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HTTPMethodController : ControllerBase
    {
        private readonly IOperations<HTTPMethods> _operationService;

        public HTTPMethodController(IOperations<HTTPMethods> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<HTTPMethods>> GetAllAsync()
        {
            IEnumerable<HTTPMethods> data = await _operationService.GetAll();

            return data;
        }
    }
}

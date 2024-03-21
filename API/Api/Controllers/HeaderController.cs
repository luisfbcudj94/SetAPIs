using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeaderController : ControllerBase
    {
        private readonly IOperations<Header> _operationService;

        public HeaderController(IOperations<Header> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Header>> GetAllAsync()
        {
            IEnumerable<Header> data = await _operationService.GetAll();

            return data;
        }
    }
}

using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeaderTagController : ControllerBase
    {
        private readonly IOperations<HeaderTag> _operationService;

        public HeaderTagController(IOperations<HeaderTag> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<HeaderTag>> GetAllAsync()
        {
            IEnumerable<HeaderTag> data = await _operationService.GetAll();

            return data;
        }
    }
}

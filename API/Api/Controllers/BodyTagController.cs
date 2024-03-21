using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyTagController : ControllerBase
    {
        private readonly IOperations<BodyTag> _operationService;

        public BodyTagController(IOperations<BodyTag> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<BodyTag>> GetAllAsync()
        {
            IEnumerable<BodyTag> data = await _operationService.GetAll();

            return data;
        }
    }
}

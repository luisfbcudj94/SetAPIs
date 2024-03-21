using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class URLTagController : ControllerBase
    {
        private readonly IOperations<URLTag> _operationService;

        public URLTagController(IOperations<URLTag> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<URLTag>> GetAllAsync()
        {
            IEnumerable<URLTag> data = await _operationService.GetAll();

            return data;
        }
    }
}

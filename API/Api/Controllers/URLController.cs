using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class URLController : ControllerBase
    {
        private readonly IOperations<URL> _operationService;

        public URLController(IOperations<URL> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<URL>> GetAllAsync()
        {
            IEnumerable<URL> data = await _operationService.GetAll();

            return data;
        }
    }
}

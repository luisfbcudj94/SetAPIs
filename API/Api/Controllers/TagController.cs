using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly IOperations<Tag> _operationService;

        public TagController(IOperations<Tag> operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            IEnumerable<Tag> data = await _operationService.GetAll();

            return data;
        }
    }
}

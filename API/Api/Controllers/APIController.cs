using API.Application.Contracts.Interfaces;
using API.Application.Services;
using API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {
        private readonly IOperations<API.Domain.Models.API> _operationService;

        public APIController(IOperations<API.Domain.Models.API> operationService)
        {
            _operationService = operationService;
        }


        [HttpGet]
        public async Task<IEnumerable<API.Domain.Models.API>> GetAllAsync()
        {
            IEnumerable<API.Domain.Models.API> data = await _operationService.GetAll();

            return data;
        }
    }
}

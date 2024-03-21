using API.Application.Contracts.DTOs;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HTTPMethodController : ControllerBase
    {
        private readonly IOperations<HTTPMethods> _operationService;
        private readonly IMapper _mapper;

        public HTTPMethodController(
            IOperations<HTTPMethods> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HTTPMethodDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<HTTPMethodDTO>>(data);
        }
    }
}

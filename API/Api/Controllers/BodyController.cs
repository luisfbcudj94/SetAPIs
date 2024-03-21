using API.Application.Contracts.DTOs;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyController : ControllerBase
    {
        private readonly IOperations<Body> _operationService;
        private readonly IMapper _mapper;

        public BodyController(
            IOperations<Body> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BodyDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<BodyDTO>>(data);
        }
    }
}

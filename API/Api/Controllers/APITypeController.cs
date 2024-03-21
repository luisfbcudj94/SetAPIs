using API.Application.Contracts.DTOs;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APITypeController : ControllerBase
    {
        private readonly IOperations<APIType> _operationService;
        private readonly IMapper _mapper;

        public APITypeController(
            IOperations<APIType> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<APITypeDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<APITypeDTO>>(data);
        }
    }
}

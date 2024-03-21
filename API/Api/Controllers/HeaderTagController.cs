using API.Application.Contracts.DTOs;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeaderTagController : ControllerBase
    {
        private readonly IOperations<HeaderTag> _operationService;
        private readonly IMapper _mapper;

        public HeaderTagController(
            IOperations<HeaderTag> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HeaderTagDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<HeaderTagDTO>>(data);
        }
    }
}

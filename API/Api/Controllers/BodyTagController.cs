using API.Application.Contracts.DTOs;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyTagController : ControllerBase
    {
        private readonly IOperations<BodyTag> _operationService;
        private readonly IMapper _mapper;

        public BodyTagController(
            IOperations<BodyTag> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BodyTagDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<BodyTagDTO>>(data);
        }
    }
}

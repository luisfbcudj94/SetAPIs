using API.Application.Contracts.DTOs;
using API.Application.Contracts.Interfaces;
using API.Application.Services;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {
        private readonly IOperations<API.Domain.Models.API> _operationService;
        private readonly IMapper _mapper;

        public APIController(
            IOperations<API.Domain.Models.API> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<APIDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<APIDTO>>(data);
        }
    }
}

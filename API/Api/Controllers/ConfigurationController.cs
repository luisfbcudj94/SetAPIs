using API.Application.Contracts.DTOs.Body;
using API.Application.Contracts.DTOs.Configuration;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IOperations<Configuration> _operationService;
        private readonly IMapper _mapper;

        public ConfigurationController(
            IOperations<Configuration> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ConfigurationDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<ConfigurationDTO>>(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigurationDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<ConfigurationDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<ConfigurationDTO>> CreateAsync(ConfigurationDTO input)
        {
            var data = _mapper.Map<Configuration>(input);

            return Ok(_mapper.Map<ConfigurationDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, ConfigurationDTO input)
        {
            if (id != input.Id)
            {
                return BadRequest();
            }

            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }

            var update = _mapper.Map<Configuration>(input);
            try
            {
                return Ok(_mapper.Map<ConfigurationDTO>(await _operationService.Update(update)));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }

            await _operationService.Delete(id);

            return Ok();
        }
    }
}

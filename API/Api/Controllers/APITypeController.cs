using API.Application.Contracts.DTOs.API;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<APITypeDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<APITypeDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<APITypeDTO>> CreateAsync(APITypeDTO input)
        {
            var data = _mapper.Map<APIType>(input);

            return Ok(_mapper.Map<APITypeDTO>( await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, APITypeDTO input)
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

            var update = _mapper.Map<APIType>(input);
            try
            {
                return Ok(await _operationService.Update(update));
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

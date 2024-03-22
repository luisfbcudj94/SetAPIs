using API.Application.Contracts.DTOs.API;
using API.Application.Contracts.DTOs.Body;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<BodyDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<BodyDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<BodyDTO>> CreateAsync(BodyDTO input)
        {
            var data = _mapper.Map<Body>(input);

            return Ok(_mapper.Map<BodyDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, BodyDTO input)
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

            var update = _mapper.Map<Body>(input);
            try
            {
                return Ok(_mapper.Map<BodyDTO>(await _operationService.Update(update)));
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

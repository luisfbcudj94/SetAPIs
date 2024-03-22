using API.Application.Contracts.DTOs.Header;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet("{id}")]
        public async Task<ActionResult<HeaderTagDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<HeaderTagDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<HeaderTagDTO>> CreateAsync(HeaderTagDTO input)
        {
            var data = _mapper.Map<HeaderTag>(input);

            return Ok(_mapper.Map<HeaderTagDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, HeaderTagDTO input)
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

            var update = _mapper.Map<HeaderTag>(input);
            try
            {
                return Ok(_mapper.Map<HeaderTagDTO>(await _operationService.Update(update)));
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

using API.Application.Contracts.DTOs.Configuration;
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
    public class HeaderController : ControllerBase
    {
        private readonly IOperations<Header> _operationService;
        private readonly IMapper _mapper;

        public HeaderController(
            IOperations<Header> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HeaderDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<HeaderDTO>>(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HeaderDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<HeaderDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<HeaderDTO>> CreateAsync(HeaderDTO input)
        {
            var data = _mapper.Map<Header>(input);

            return Ok(_mapper.Map<HeaderDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, HeaderDTO input)
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

            var update = _mapper.Map<Header>(input);
            try
            {
                return Ok(_mapper.Map<HeaderDTO>(await _operationService.Update(update)));
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

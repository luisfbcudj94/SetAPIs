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


        [HttpGet("{id}")]
        public async Task<ActionResult<BodyTagDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<BodyTagDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<BodyTagDTO>> CreateAsync(BodyTagDTO input)
        {
            var data = _mapper.Map<BodyTag>(input);

            return Ok(_mapper.Map<BodyTagDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, BodyTagDTO input)
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

            var update = _mapper.Map<BodyTag>(input);
            try
            {
                return Ok(_mapper.Map<BodyTagDTO>(await _operationService.Update(update)));
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

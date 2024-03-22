using API.Application.Contracts.DTOs.HTTPMethod;
using API.Application.Contracts.DTOs.Tag;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly IOperations<Tag> _operationService;
        private readonly IMapper _mapper;

        public TagController(
            IOperations<Tag> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<TagDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<TagDTO>>(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TagDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<TagDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<TagDTO>> CreateAsync(TagDTO input)
        {
            var data = _mapper.Map<Tag>(input);

            return Ok(_mapper.Map<TagDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, TagDTO input)
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

            var update = _mapper.Map<Tag>(input);
            try
            {
                return Ok(_mapper.Map<TagDTO>(await _operationService.Update(update)));
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

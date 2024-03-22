using API.Application.Contracts.DTOs.URL;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class URLTagController : ControllerBase
    {
        private readonly IOperations<URLTag> _operationService;
        private readonly IMapper _mapper;

        public URLTagController(
            IOperations<URLTag> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<URLTagDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<URLTagDTO>>(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<URLTagDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<URLTagDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<URLTagDTO>> CreateAsync(URLTagDTO input)
        {
            var data = _mapper.Map<URLTag>(input);

            return Ok(_mapper.Map<URLTagDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, URLTagDTO input)
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

            var update = _mapper.Map<URLTag>(input);
            try
            {
                return Ok(_mapper.Map<URLTagDTO>(await _operationService.Update(update)));
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

using API.Application.Contracts.DTOs.Tag;
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
    public class URLController : ControllerBase
    {
        private readonly IOperations<URL> _operationService;
        private readonly IMapper _mapper;

        public URLController(
            IOperations<URL> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<URLDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<URLDTO>>(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<URLDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<URLDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<URLDTO>> CreateAsync(URLDTO input)
        {
            var data = _mapper.Map<URL>(input);

            return Ok(_mapper.Map<URLDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, URLDTO input)
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

            var update = _mapper.Map<URL>(input);
            try
            {
                return Ok(_mapper.Map<URLDTO>(await _operationService.Update(update)));
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

using API.Application.Contracts.DTOs.Header;
using API.Application.Contracts.DTOs.HTTPMethod;
using API.Application.Contracts.Interfaces;
using API.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HTTPMethodController : ControllerBase
    {
        private readonly IOperations<HTTPMethods> _operationService;
        private readonly IMapper _mapper;

        public HTTPMethodController(
            IOperations<HTTPMethods> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HTTPMethodDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<HTTPMethodDTO>>(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HTTPMethodDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<HTTPMethodDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<HTTPMethodDTO>> CreateAsync(HTTPMethodDTO input)
        {
            var data = _mapper.Map<HTTPMethods>(input);

            return Ok(_mapper.Map<HTTPMethodDTO>(await _operationService.Add(data)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, HTTPMethodDTO input)
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

            var update = _mapper.Map<HTTPMethods>(input);
            try
            {
                return Ok(_mapper.Map<HTTPMethodDTO>(await _operationService.Update(update)));
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

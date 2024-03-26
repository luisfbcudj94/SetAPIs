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
    public class APIController : ControllerBase
    {
        private readonly IOperations<API.Domain.Models.API> _operationService;
        private readonly IMapper _mapper;

        public APIController(
            IOperations<API.Domain.Models.API> operationService,
            IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<APIDTO>> GetAllAsync()
        {
            var data = await _operationService.GetAll();

            return _mapper.Map<IEnumerable<APIDTO>>(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIDTO>> GetByIdAsync(Guid id)
        {
            var data = await _operationService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<APIDTO>(data);
        }

        [HttpPost]
        public async Task<ActionResult<APIDTO>> CreateAsync(APIDTO input)
        {
            var data = _mapper.Map<API.Domain.Models.API>(input);

            return Ok(_mapper.Map<APIDTO>(await _operationService.Add(data)));
        }

        //[HttpPost]
        //public async Task<ActionResult<API.Domain.Models.API>> CreateAsync(API.Domain.Models.API input)
        //{
        //    var data = await _operationService.Add(input);
        //    return Ok(data);
        //}


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, APIDTO input)
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

            var update = _mapper.Map<API.Domain.Models.API>(input);
            try
            {
                return Ok(_mapper.Map<APIDTO>(await _operationService.Update(update)));
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

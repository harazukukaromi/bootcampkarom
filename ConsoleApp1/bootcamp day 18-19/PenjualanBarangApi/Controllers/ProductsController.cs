using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenjualanBarangApi.DTOs;
using PenjualanBarangApi.Interfaces;
using PenjualanBarangApi.Models;

namespace PenjualanBarangApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductReadDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductReadDTO>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDTO>> Create(ProductCreateDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.AddAsync(product);
            await _repository.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, _mapper.Map<ProductReadDTO>(product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDTO dto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();

            _mapper.Map(dto, product);
            await _repository.UpdateAsync(product);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();

            await _repository.DeleteAsync(product);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


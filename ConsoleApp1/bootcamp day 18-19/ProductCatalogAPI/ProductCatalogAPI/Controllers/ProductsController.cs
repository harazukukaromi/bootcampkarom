using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.DTOs;
using ProductCatalogAPI.Services;

namespace ProductCatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET /api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSummaryDto>>> GetProducts(
            [FromQuery] bool activeOnly = true,
            [FromQuery] int? categoryId = null,
            [FromQuery] string? search = null)
        {
            try
            {
                IEnumerable<ProductSummaryDto> products;

                if (!string.IsNullOrWhiteSpace(search))
                {
                    products = await _productService.SearchProductsAsync(search);
                }
                else if (categoryId.HasValue)
                {
                    products = await _productService.GetProductsByCategoryAsync(categoryId.Value);
                }
                else if (activeOnly)
                {
                    products = await _productService.GetActiveProductsAsync();
                }
                else
                {
                    products = await _productService.GetAllProductsAsync();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving products", error = ex.Message });
            }
        }

        // GET /api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                
                if (product == null)
                {
                    return NotFound(new { message = $"Product with ID {id} not found" });
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the product", error = ex.Message });
            }
        }

        // POST /api/products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdProduct = await _productService.CreateProductAsync(createProductDto);

                return CreatedAtAction(
                    nameof(GetProduct),
                    new { id = createdProduct.Id },
                    createdProduct);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the product", error = ex.Message });
            }
        }

        // PUT /api/products/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(id, updateProductDto);
                
                if (updatedProduct == null)
                {
                    return NotFound(new { message = $"Product with ID {id} not found" });
                }

                return Ok(updatedProduct);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product", error = ex.Message });
            }
        }

        // DELETE /api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id);
                
                if (!result)
                {
                    return NotFound(new { message = $"Product with ID {id} not found" });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the product", error = ex.Message });
            }
        }

        // POST /api/products/{id}/deactivate
        [HttpPost("{id}/deactivate")]
        public async Task<IActionResult> DeactivateProduct(int id)
        {
            try
            {
                var result = await _productService.DeactivateProductAsync(id);
                
                if (!result)
                {
                    return NotFound(new { message = $"Product with ID {id} not found" });
                }

                return Ok(new { message = $"Product with ID {id} has been deactivated" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deactivating the product", error = ex.Message });
            }
        }
    }
}
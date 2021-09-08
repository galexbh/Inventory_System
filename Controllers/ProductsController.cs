using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Data.Interfaces;
using Inventory_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Inventory_System.Dtos;

namespace Inventory_System.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {
            return Ok(await _repository.GetProductsAsync());
        }

        [HttpGet("brand/{brand}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string brand)
        {
            return Ok(await _repository.GetProductByBrandAsync(brand));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product != null)
                NotFound("Product not found");
            return Ok(product);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(ProductCreateDto productDto)
        {
            var productToCreate = _mapper.Map<Product>(productDto);
            _repository.Add(productToCreate);

            if (await _repository.SaveAll())
                return Ok(productToCreate);
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProductUpdateDto productDto)
        {
            if (id != productDto.ProductId)
                return BadRequest("Ids do not match");

            var productToUpdate = await _repository.GetProductByIdAsync(productDto.ProductId);

            if (productToUpdate == null)
                return BadRequest();

            _mapper.Map(productDto, productToUpdate);

            if (!await _repository.SaveAll())
                return NoContent();

            return Ok(productToUpdate);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
                return NotFound("Product not found");

            _repository.Delete(product);
            if (!await _repository.SaveAll())
                return NoContent();

            return Ok("Product deleted");
        }
    }
}
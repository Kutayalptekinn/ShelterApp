﻿
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Business.Services.ProductService;
using ShelterApp.Entities.Entities.Product.dtos;

namespace ShelterApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductAppService _appService;

        public ProductController(IProductAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetList()
        {
            var result = ((await _appService.GetListAsyncForAPI()));

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = (await _appService.GetAsync(id));

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpGet("GetByIsimAsync")]
        public async Task<IActionResult> GetByName(string isim)
        {
            var result = (await _appService.GetByIsimAsync(isim));

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> Insert(CreateProductDto branch)
        {
            var result = (await _appService.CreateAsync(branch));

            if (result.ID > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> Update(UpdateProductDto branch)
        {
            var result = (await _appService.UpdateAsync(branch));

            if (result.ID > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appService.DeleteAsync(id);

            return Ok();
        }
    }
}

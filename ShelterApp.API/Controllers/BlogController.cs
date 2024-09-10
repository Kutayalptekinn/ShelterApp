﻿
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Business.Services.BlogService;
using ShelterApp.Entities.Entities.Blog.dtos;

namespace ShelterApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController:ControllerBase
    {
        private IBlogAppService _appService;

        public BlogController(IBlogAppService appService)
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
        [HttpGet("GetByBaslikAsync")]
        public async Task<IActionResult> GetByBaslik(string baslik)
        {
            var result = (await _appService.GetByBaslikAsync(baslik));

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> Insert(CreateBlogDto branch)
        {
            var result = (await _appService.CreateAsync(branch));

            if (result.ID > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> Update(UpdateBlogDto branch)
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

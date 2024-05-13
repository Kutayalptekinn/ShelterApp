using Microsoft.AspNetCore.Mvc;
using ShelterApp.Business.Services.BlogService;
using ShelterApp.Entities.Entities.Blog.dtos;

namespace ShelterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private IBlogAppService _appService;

        public BlogController(IBlogAppService appService)
        {
            _appService = appService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetList()
        {
            var result = (await _appService.GetListAsync()).ToList();

            if (result.Count > 0)
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

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> Insert(CreateBlogDto blog)
        {
            var result = (await _appService.CreateAsync(blog));

            if (result.ID > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> Update(UpdateBlogDto blog)
        {
            var result = (await _appService.UpdateAsync(blog));

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

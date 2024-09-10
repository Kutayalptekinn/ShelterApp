
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Business.Services.SectorService;
using ShelterApp.Entities.Entities.Sector.dtos;

namespace ShelterApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private ISectorAppService _appService;

        public SectorController(ISectorAppService appService)
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
        [HttpGet("GetByNameAsync")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = (await _appService.GetByNameAsync(name));

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> Insert(CreateSectorDto branch)
        {
            var result = (await _appService.CreateAsync(branch));

            if (result.ID > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> Update(UpdateSectorDto branch)
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

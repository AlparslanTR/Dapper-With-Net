using EstateAPI.Repositories.CityRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepo _repo;

        public CityController(ICityRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWithEstateCount()
        {
            return Ok(await _repo.GetAllWithEstateCount());
        }
    }
}

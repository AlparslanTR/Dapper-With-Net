using EstateAPI.Dtos.Estate;
using EstateAPI.Repositories.EstateRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly IEstateRepo _repo;

        public EstateController(IEstateRepo repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("EstateListWithCategory")]
        public async Task<IActionResult> GetAllWithCategory()
        {
            return Ok(await _repo.GetAllWithCategory());
        }

        [HttpGet("EstateListWithEmployee")]
        public async Task<IActionResult> GetAllWithEmployee()
        {
            return Ok(await _repo.GetAllWithEmployee());
        }

        [HttpPost]
        public async Task<IActionResult> Add(EstateCreateDto request)
        {
            return Ok(await _repo.Create(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EstateUpdateDto request)
        {
            return Ok(await _repo.Update(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repo.GetById(id));   
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}

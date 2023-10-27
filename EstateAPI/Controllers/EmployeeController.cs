using EstateAPI.Repositories.EmployeeRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _Repo;

        public EmployeeController(IEmployeeRepo repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            return Ok(await _Repo.GetAll());
        }
    }
}

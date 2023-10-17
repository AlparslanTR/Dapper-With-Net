using EstateAPI.Repositories.EmployeeRelationComment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeRelationsCommentsController : ControllerBase
    {
        private readonly IRelationCommentRepo _repo;

        public EmployeeRelationsCommentsController(IRelationCommentRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            return Ok(await _repo.GetCommentsWithEmployee());
        }
    }
}

﻿using EstateAPI.Dtos.Category;
using EstateAPI.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstateAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryController(ICategoryRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
           return Ok(await _repo.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult>Add(CategoryCreateDto request)
        {
            return Ok(await _repo.Create(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }

        [HttpPut]
        public async Task<IActionResult>Update(CategoryUpdateDto request)
        {
            return Ok(await _repo.Update(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repo.GetById(id));
        }
    }
}

using Azure;
using IntelifoxCodingChallenge.Core.Models;
using IntelifoxCodingChallenge.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntelifoxCodingChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.Categories.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Categories.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> CountAsync()
        {
            var result = await _unitOfWork.Categories.CountAsync();
            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddArticle(Category category)
        {
            if (category != null)
            {
                var result = await _unitOfWork.Categories.AddAsync(category);
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateArticle(Category category)
        {
            if (category != null)
            {
                var result = _unitOfWork.Categories.Update(category);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteCategory")]
        public void DeleteArticle(Category category)
        {
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
            }
        }
    }
}

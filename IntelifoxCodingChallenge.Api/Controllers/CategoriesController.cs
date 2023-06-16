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

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Categories.GetById(id));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.Categories.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Categories.GetAll();
            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public IActionResult AddArticle(Category category)
        {
            if (category != null)
            {
                var result = _unitOfWork.Categories.Add(category);
                return Ok(result);

            }
            return BadRequest();
        }
    }
}

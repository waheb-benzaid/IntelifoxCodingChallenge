using AutoMapper;
using Azure;
using IntelifoxCodingChallenge.Core.Dtos;
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
        private readonly IMapper _mapper;
        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var result = await _unitOfWork.Categories.GetByIdAsync(id);
                var categoryDto = _mapper.Map<CategoryDTO>(result);
                return Ok(categoryDto);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Categories.GetAllAsync();
            var categoryDto = _mapper.Map<CategoryDTO>(result);
            return Ok(categoryDto);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> CountAsync()
        {
            var result = await _unitOfWork.Categories.CountAsync();
            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddArticle(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            if (category != null)
            {
                var result = await _unitOfWork.Categories.AddAsync(category);
                var createdArticleDto = _mapper.Map<CategoryDTO>(result);
                return Ok(createdArticleDto);
            }
            return BadRequest();
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateArticle(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            if (category != null)
            {
                var result = _unitOfWork.Categories.Update(category);
                var updatedArticleDto = _mapper.Map<CategoryDTO>(result);
                return Ok(updatedArticleDto);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteCategory")]
        public void DeleteArticle(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
            }
        }
    }
}

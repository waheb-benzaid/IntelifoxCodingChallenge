using IntelifoxCodingChallenge.Core.Models;
using IntelifoxCodingChallenge.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace IntelifoxCodingChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticlesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id != null)
            {
                var result = _unitOfWork.Articles.GetById(id);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id != null)
            {
                var result = await _unitOfWork.Articles.GetByIdAsync(id);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var result = _unitOfWork.Articles.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("Count")]
        public IActionResult CountAsync()
        {
            var result = _unitOfWork.Articles.CountAsync();
            return Ok(result);
        }

        [HttpPost("AddArticle")]
        public async Task<IActionResult> AddArticle(Article article)
        {
            if (article != null)
            {
                var result = await _unitOfWork.Articles.AddAsync(article);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("UpdateArticle")]
        public IActionResult UpdateArticle(Article article)
        {
            if (article != null)
            {
                var result = _unitOfWork.Articles.Update(article);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteArticle")]
        public void DeleteArticle(Article article)
        {
            if (article != null)
            {
                _unitOfWork.Articles.Delete(article);
            }
        }
    }
}

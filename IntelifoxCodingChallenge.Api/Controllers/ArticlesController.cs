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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Articles.GetAll();
            return Ok(result);
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle(Article article)
        {
            if (article != null)
            {
                var result = _unitOfWork.Articles.Add(article);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

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
        private readonly IBaseRepository<Article> _articlesRepository;
        public ArticlesController(IBaseRepository<Article> articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _articlesRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _articlesRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _articlesRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string title)
        {
            var result = _articlesRepository.Find(b => b.Title == title);
            return Ok(result);
        }
    }
}

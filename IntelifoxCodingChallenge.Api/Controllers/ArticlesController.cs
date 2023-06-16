using AutoMapper;
using IntelifoxCodingChallenge.Core.Dtos;
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
        private readonly IMapper _mapper;
        public ArticlesController(IUnitOfWork unitOfWork, IMapper mapper)
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
                var result = await _unitOfWork.Articles.GetByIdAsync(id);
                var articleDto = _mapper.Map<ArticleDTO>(result);
                return Ok(articleDto);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _unitOfWork.Articles.GetAllAsync();
            var articleDto = _mapper.Map<ArticleDTO>(result);
            return Ok(articleDto);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> CountAsync()
        {
            var result = await _unitOfWork.Articles.CountAsync();
            var articleDto = _mapper.Map<ArticleDTO>(result); // we can aviod the use of DTO in this case because the return value is a number
            return Ok(articleDto);
        }

        [HttpPost("AddArticle")]
        public async Task<IActionResult> AddArticle(ArticleDTO articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            if (article != null)
            {
                var result = await _unitOfWork.Articles.AddAsync(article);
                var createdArticleDto = _mapper.Map<ArticleDTO>(result);
                return Ok(createdArticleDto);
            }
            return BadRequest();
        }

        [HttpPut("UpdateArticle")]
        public IActionResult UpdateArticle(ArticleDTO articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            if (article != null)
            {
                var result = _unitOfWork.Articles.Update(article);
                var updatedArticleDto = _mapper.Map<ArticleDTO>(result);
                return Ok(updatedArticleDto);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteArticle")]
        public void DeleteArticle(ArticleDTO articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            if (article != null)
            {
                _unitOfWork.Articles.Delete(article);
            }
        }
    }
}

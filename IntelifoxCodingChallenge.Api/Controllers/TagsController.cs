using IntelifoxCodingChallenge.Core.Models;
using IntelifoxCodingChallenge.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntelifoxCodingChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _unitOfWork.Tags.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.Tags.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Tags.GetAll();
            return Ok(result);
        }

        [HttpPost("AddTag")]
        public IActionResult AddArticle(Tag tag)
        {
            if (tag != null)
            {
                var result = _unitOfWork.Tags.Add(tag);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

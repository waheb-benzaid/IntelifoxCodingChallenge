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

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.Tags.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Tags.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("AddTag")]
        public IActionResult AddArticle(Tag tag)
        {
            if (tag != null)
            {
                var result = _unitOfWork.Tags.AddAsync(tag);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("UpdateTag")]
        public IActionResult UpdateTag(Tag tag)
        {
            if (tag != null)
            {
                var result = _unitOfWork.Tags.Update(tag);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteTag")]
        public void DeleteArticle(Tag tag)
        {
            if (tag != null)
            {
                _unitOfWork.Tags.Delete(tag);
            }
        }
    }
}

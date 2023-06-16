using AutoMapper;
using IntelifoxCodingChallenge.Core.Dtos;
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
        private readonly IMapper _mapper;
        public TagsController(IUnitOfWork unitOfWork, IMapper mapper)
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
                var result = await _unitOfWork.Tags.GetByIdAsync(id);
                var tagDto = _mapper.Map<TagDTO>(result);
                return Ok(tagDto);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Tags.GetAllAsync();
            var tagDto = _mapper.Map<TagDTO>(result);
            return Ok(tagDto);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> CountAsync()
        {
            var result = await _unitOfWork.Tags.CountAsync();
            return Ok(result);
        }

        [HttpPost("AddTag")]
        public async Task<IActionResult> AddArticle(TagDTO tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            if (tag != null)
            {
                var result = await _unitOfWork.Tags.AddAsync(tag);
                var createdTag = _mapper.Map<Tag>(result);
                return Ok(createdTag);
            }
            return BadRequest();
        }

        [HttpPut("UpdateTag")]
        public IActionResult UpdateTag(TagDTO tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);
            if (tag != null)
            {
                var result = _unitOfWork.Tags.Update(tag);
                var updatedTag = _mapper.Map<Tag>(result);
                return Ok(updatedTag);
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

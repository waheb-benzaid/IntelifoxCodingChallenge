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
        private readonly IBaseRepository<Tag> _tagsRepository;
        public TagsController(IBaseRepository<Tag> tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _tagsRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _tagsRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _tagsRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var result = _tagsRepository.Find(b => b.Name == name);
            return Ok(result);
        }
    }
}

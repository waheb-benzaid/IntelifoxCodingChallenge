using IntelifoxCodingChallenge.Core.Models;
using IntelifoxCodingChallenge.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntelifoxCodingChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository<User> _userRepository;
        public UserController(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _userRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetByLastname")]
        public IActionResult GetByLastname(string lastname)
        {
            var result = _userRepository.Find(b => b.Lastname == lastname);
            return Ok(result);
        }
    }
}

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
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _unitOfWork.Users.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.Users.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Users.GetAll();
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public IActionResult AddArticle(User user)
        {
            if (user != null)
            {
                var result = _unitOfWork.Users.Add(user);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

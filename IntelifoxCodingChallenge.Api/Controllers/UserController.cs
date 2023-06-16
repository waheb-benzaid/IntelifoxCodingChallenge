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

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id != null)
            {
                var result = await _unitOfWork.Users.GetByIdAsync(id);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Users.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("Count")]
        public IActionResult CountAsync()
        {
            var result = _unitOfWork.Users.CountAsync();
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public IActionResult AddArticle(User user)
        {
            if (user != null)
            {
                var result = _unitOfWork.Users.AddAsync(user);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            if (user != null)
            {
                var result = _unitOfWork.Users.Update(user);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteUser")]
        public void DeleteArticle(User user)
        {
            if (user != null)
            {
                _unitOfWork.Users.Delete(user);
            }
        }
    }
}

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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
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
                var result = await _unitOfWork.Users.GetByIdAsync(id);
                var userDto = _mapper.Map<UserDTO>(result);
                return Ok(userDto);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Users.GetAllAsync();
            var userDto = _mapper.Map<UserDTO>(result);
            return Ok(userDto);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> CountAsync()
        {
            var result = await _unitOfWork.Users.CountAsync();
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddArticle(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            if (user != null)
            {
                var result = await _unitOfWork.Users.AddAsync(user);
                var createdUser = _mapper.Map<User>(result);
                return Ok(createdUser);
            }
            return BadRequest();
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            if (user != null)
            {
                var result = _unitOfWork.Users.Update(user);
                var updatedUser = _mapper.Map<User>(result);
                return Ok(updatedUser);
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

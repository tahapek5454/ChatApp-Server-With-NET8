using ChatApp.API.Services;
using ChatApp.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _userService.GetUserByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAllUserAsync();

            return Ok(response);    
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserVM userVM)
        {
            var id = await _userService.AddUserAsync(userVM);

            return Created($"/GetById/{id}", userVM);
        }
    }
}

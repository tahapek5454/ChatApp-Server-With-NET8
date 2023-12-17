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
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetByUsername([FromRoute] string userName)
        {
            var response = await _userService.GetUserByUserName(userName);

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

            if(id == -1)
                return Ok(id);

            return Created($"/GetById/{id}", userVM);
        }
    }
}

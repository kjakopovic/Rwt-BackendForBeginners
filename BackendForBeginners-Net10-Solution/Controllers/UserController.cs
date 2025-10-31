using BackendForBeginners_Net10_Solution.Dtos;
using BackendForBeginners_Net10_Solution.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendForBeginners_Net10_Solution.Controllers;

[Route("api/users")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsers(null);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _userService.GetUsers(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newUser = await _userService.CreateUser(user);

        return Ok(new
        {
            newUser.Id,
            newUser.Username,
            newUser.Email,
            newUser.CreatedAt,
            newUser.UpdatedAt
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto updatedUser)
    {
        var user = await _userService.UpdateUser(updatedUser, id);

        return Ok(new
        {
            user.Id,
            user.Username,
            user.Email,
            user.CreatedAt,
            user.UpdatedAt
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteUser(id);
        return Ok(new
        {
            Message = "User deleted successfully"
        });
    }
}

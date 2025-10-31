using BackendForBeginners_Net10_Solution.Dtos;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;

namespace BackendForBeginners_Net10_Solution.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var newUser = new Models.User
        {
            Username = user.Username,
            Email = user.Email,
            Password = hashedPassword
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UserDto updatedUser)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Username = updatedUser.Username;
        user.Email = updatedUser.Email;
        user.Password = updatedUser.Password;
        user.UpdatedAt = DateTime.UtcNow;

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return Ok();
    }
}

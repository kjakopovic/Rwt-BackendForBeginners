using System.ComponentModel.DataAnnotations;

namespace BackendForBeginners_Net10_Solution.Dtos;

public class UserDto
{
    [MaxLength(50)]
    public required string Username { get; set; }

    [MaxLength(100)]
    [EmailAddress]
    public required string Email { get; set; }

    [MinLength(8)]
    public required string Password { get; set; }
}

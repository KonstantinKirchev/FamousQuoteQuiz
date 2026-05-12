using System.ComponentModel.DataAnnotations;


namespace FamousQuoteQuiz.Application.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public required string Firstname { get; set; }

    [Required]
    public required string Lastname { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    public required string UserName { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
}

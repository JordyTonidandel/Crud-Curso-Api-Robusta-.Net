using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
  public class CreateUserViewModels
  {
    [Required(ErrorMessage = "The name can't be empty")]
    [MaxLength(80, ErrorMessage = "Max Lenght of the name should be 80 characters")]
    [MinLength(3, ErrorMessage = "Min Lenght of the name should be 3 characres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The email can't be empty")]
    [MaxLength(180, ErrorMessage = "Max Lenght of the email should be 180 characters")]
    [MinLength(10, ErrorMessage = "Min Lenght of the email should be 10 characres")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                  ErrorMessage = "The email format is invalid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The password can't be empty")]
    [MaxLength(80, ErrorMessage = "Max Lenght of the password should be 80 characters")]
    [MinLength(6, ErrorMessage = "Min Lenght of the password should be 6 characres")]
    public string Password { get; set; }
  }
}

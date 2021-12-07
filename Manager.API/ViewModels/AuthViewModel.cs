using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.ViewModels
{
  public class AuthViewModel
  {
    [Required(ErrorMessage = "The login can not be empty")]
    public string Login { get; set; }
    [Required(ErrorMessage = "The password can not be empty")]
    public string Password { get; set; }
  }
}

using System;
using Manager.API.Token;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Manager.API.Controllers
{
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
    {
      _configuration = configuration;
      _tokenGenerator = tokenGenerator;
    }

    [HttpPost]
    [Route("api/v1/auth/login")]
    public IActionResult Login([FromBody] AuthViewModel authViewModel)
    {
      try
      {
        var tokenLogin = _configuration["Jwt:Login"];
        var tokenPassword = _configuration["Jwt:Password"];

        if (authViewModel.Login == tokenLogin && authViewModel.Password == tokenPassword)
        {
          return Ok(new ResultViewModel
          {
            Message = "User Auth Sucefully",
            Success = true,
            Data = new
            {
              Token = _tokenGenerator.GenerateToken(),
              TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
            }
          });
        }
        else
        {
          return StatusCode(401, Responses.UnauthorizedErrorMessage());
        }
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }
  }
}

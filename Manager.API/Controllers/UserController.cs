using System;
using System.Threading.Tasks;
using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
  [ApiController]
  public class UserController : ControllerBase
  {
    public readonly IMapper _mapper;
    public readonly IUserService _userService;

    public UserController(IMapper mapper, IUserService userService)
    {
      _mapper = mapper;
      _userService = userService;
    }

    [HttpPost]
    [Authorize]
    [Route("/api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModels userViewModel)
    {
      try
      {
        var userDTO = _mapper.Map<UserDTO>(userViewModel);

        var userCreated = await _userService.Create(userDTO);

        return Ok(new ResultViewModel
        {
          Message = "User Created",
          Success = true,
          Data = userCreated
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpPut]
    [Authorize]
    [Route("/api/v1/users/update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserViewModels updateUserViewModels)
    {
      try
      {
        var userDTO = _mapper.Map<UserDTO>(updateUserViewModels);

        var userUpdated = await _userService.Update(userDTO);

        return Ok(new ResultViewModel
        {
          Message = "User Updated",
          Success = true,
          Data = userUpdated
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpDelete]
    [Authorize]
    [Route("/api/v1/users/remove/{id}")]
    public async Task<IActionResult> Remove(long id)
    {
      try
      {
        await _userService.Remove(id);

        return Ok(new ResultViewModel
        {
          Message = "User Deleted",
          Success = true,
          Data = null
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpGet]
    [Authorize]
    [Route("/api/v1/users/get/{id}")]
    public async Task<IActionResult> Get(long id)
    {
      try
      {
        var users = await _userService.Get(id);

        if (users == null)
        {
          return Ok(new ResultViewModel
          {
            Message = "User not found with this id",
            Success = true,
            Data = users
          });
        }

        return Ok(new ResultViewModel
        {
          Message = "User finded",
          Success = true,
          Data = users
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpGet]
    [Authorize]
    [Route("/api/v1/users/get-all")]
    public async Task<IActionResult> Get()
    {
      try
      {
        var allUsers = await _userService.Get();

        return Ok(new ResultViewModel
        {
          Message = "Users finded",
          Success = true,
          Data = allUsers
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpGet]
    [Authorize]
    [Route("/api/v1/users/get/get-by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
      try
      {
        var user = await _userService.GetByEmail(email);

        if (user == null)
        {
          return Ok(new ResultViewModel
          {
            Message = "User not found with this email",
            Success = true,
            Data = user
          });
        }

        return Ok(new ResultViewModel
        {
          Message = "User finded",
          Success = true,
          Data = user
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpGet]
    [Authorize]
    [Route("/api/v1/users/get/search-by-name")]
    public async Task<IActionResult> GetByName([FromQuery] string name)
    {
      try
      {
        var users = await _userService.SearchByName(name);

        if (users == null)
        {
          return Ok(new ResultViewModel
          {
            Message = "User not found with this name",
            Success = true,
            Data = users
          });
        }

        return Ok(new ResultViewModel
        {
          Message = "User finded",
          Success = true,
          Data = users
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }

    [HttpGet]
    [Authorize]
    [Route("/api/v1/users/get/search-by-email")]
    public async Task<IActionResult> SearchByName([FromQuery] string email)
    {
      try
      {
        var users = await _userService.SearchByEmail(email);

        if (users == null)
        {
          return Ok(new ResultViewModel
          {
            Message = "Users not found with this email",
            Success = true,
            Data = users
          });
        }

        return Ok(new ResultViewModel
        {
          Message = "User finded",
          Success = true,
          Data = users
        });
      }
      catch (DomainExceptions ex)
      {
        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Error));
      }
      catch (Exception)
      {
        return StatusCode(500, Responses.ApplicationErrorMessage());
      }
    }
  }
}

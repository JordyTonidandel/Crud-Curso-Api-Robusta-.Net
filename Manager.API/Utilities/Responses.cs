using System.Collections.Generic;
using Manager.API.ViewModels;

namespace Manager.API.Utilities
{
  public static class Responses
  {
    public static ResultViewModel ApplicationErrorMessage()
    {
      return new ResultViewModel
      {
        Message = "Some Error ocurred in application, please try again",
        Success = false,
        Data = null
      };
    }

    public static ResultViewModel DomainErrorMessage(string message)
    {
      return new ResultViewModel
      {
        Message = message,
        Success = false,
        Data = null
      };
    }

    public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
      return new ResultViewModel
      {
        Message = message,
        Success = false,
        Data = errors
      };
    }

    public static ResultViewModel UnauthorizedErrorMessage()
    {
      return new ResultViewModel
      {
        Message = "The user or password is wrong",
        Success = false,
        Data = null
      };
    }
  }
}

using Lagalt;
using Microsoft.AspNetCore.Mvc;

namespace lagalt
{

  /// <summary>
  /// Handle user registeration
  /// </summary>
  public interface IUserAccountRepository
  {
    Task<ActionResult<UserDto>> RegisterAsync(RegisterAppUserDto registerAppUserDto);

    Task<ActionResult<UserDto>> LoginAsync(LoginDto loginDto);

  }
}
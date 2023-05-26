using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Core.Contracts;
using TasksAPI.Database.Data.Models.Account;
using TasksAPI.Models;

namespace TasksAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class Account : ControllerBase
{
    private UserManager<ApplicationUser> _userManager;
    private ITokenService _tokenService;

    public Account(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new ApplicationUser()
        {
            Email = model.Email,
            NormalizedEmail = model.Email.ToUpper(),
            UserName = model.Email,
            NormalizedUserName = model.Email.ToUpper(),
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
                return BadRequest(ModelState);
            }
        }

        model.Password = "";
        return CreatedAtAction(nameof(Register), new { email = model.Email }, model);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid credentials.");
        }

        var managedUser = await _userManager.FindByEmailAsync(model.Email);

        if (managedUser == null)
        {
            return BadRequest("Invalid credentials.");
        }

        var result = await _userManager.CheckPasswordAsync(managedUser, model.Password);

        if (!result)
        {
            return BadRequest("Invalid credentials.");
        }

        var response = _tokenService.LoginUser(managedUser);

        return Ok(response);
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;
using SingleDailyBugle.Models.ViewModels;
using SingleDailyBugle.Services;

namespace SingleDailyBugle.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenCreationService _jwtService;
    public UsersController(UserManager<ApplicationUser> userManager, ITokenCreationService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    [HttpPost(nameof(Register))]
    public async Task<ActionResult<RegistrationForm>> Register(RegistrationForm registrationForm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        ApplicationUser user = new ApplicationUser
        {
            UserName = registrationForm.UserName,
            Email = registrationForm.Email,
            Role = registrationForm.Role,
        };
        var result = await _userManager.CreateAsync(
            user,
            registrationForm.Password
        );

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        IdentityResult identityResult = new();

        if (registrationForm.Role.Equals("Journalist"))
        {
            identityResult = await _userManager.AddToRoleAsync(user, role: "Journalist");
        }

        if (registrationForm.Role.Equals("Reader"))
        {
            identityResult = await _userManager.AddToRoleAsync(user, role: "Reader");
        }

        if (!identityResult.Succeeded)
        {
            throw new Exception("Failed to add user to role");
        }

        return Ok();
    }

    [HttpPost(nameof(CreateBearerToken))]
    public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad credentials");
        }

        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        IList<string> roles = await _userManager.GetRolesAsync(user);

        var token = _jwtService.CreateToken(user, roles);

        return Ok(token);
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManager.Db;
using PropertyManager.Models;

namespace PropertyManager.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly DatabaseContext _dbContext;
    private readonly IMapper _mapper;


    public AuthController(
        ILogger<AuthController> logger, 
        DatabaseContext dbContext,
        IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<Resident>> Register(RegisterViewModel request)
    {
        var user = Resident.CreateResident(request);
        await _dbContext.Residents.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return Ok(user);
    }

    [HttpGet("login")]
    public IActionResult Login([FromQuery] string? returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromForm] LoginViewModel request, [FromQuery] string? returnUrl)
    {
        

        Resident user = await _dbContext.Residents.Where(val => val.Email == request.Email).FirstOrDefaultAsync();
        if (user != null)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
            return Redirect(returnUrl);   
        }
        else
        {
            TempData["Error"] = "Invalid username or password.";
            return View("login");
        }
    }
}   

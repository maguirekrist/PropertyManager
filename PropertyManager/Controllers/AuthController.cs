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
    public async Task<ActionResult> Register([FromForm] RegisterViewModel request)
    {
        if(ModelState.IsValid)
        {
            var user = Resident.CreateResident(request);
            _dbContext.Residents.Add(user);
            await _dbContext.SaveChangesAsync();
            await SignInUser(user);
            return Redirect("/");
        }

        return View();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/Auth/login");
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
        if (ModelState.IsValid)
        {
            var user = await _dbContext.Residents.Where(val => val.Email == request.Email).FirstOrDefaultAsync();
            var isValidPass = user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (user != null && isValidPass)
            {
                await SignInUser(user);
                return Redirect("/");   
            }
            TempData["Error"] = "Invalid username or password.";
            return View();
        }
        TempData["Error"] = "Invalid username or password.";
        return View();
    }

    [HttpGet("denied")]
    public IActionResult Denied()
    {
        return View();
    }

    private async Task SignInUser(Resident user)
    {   
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim("UserId", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.isAdmin ? "Administrator" : "Resident")
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(claimsPrincipal);
    }
}   

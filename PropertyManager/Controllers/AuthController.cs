using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
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
    
    [HttpPost("register")]
    public async Task<ActionResult<Resident>> Register(RegisterViewModel request)
    {
        var user = Resident.CreateResident(request);
        await _dbContext.Residents.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<Resident>> Login(LoginViewModel request)
    {
        var user = await _dbContext.Residents.Where(val => val.Email == request.Email).FirstOrDefaultAsync();
        if (user != null)
        {
            return Ok(user);   
        }
        else
        {
            return NotFound();
        }
    }

    private string CreateToken(Resident resident)
    {
        var token = new JwtSecurityToken();

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}   

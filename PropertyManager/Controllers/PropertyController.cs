using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManager.Db;
using PropertyManager.Models;

namespace PropertyManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : Controller
{
    private readonly ILogger<PropertyController> _logger;
    private readonly DatabaseContext _dbContext;
    private readonly IMapper _mapper;
    
    public PropertyController(ILogger<PropertyController> logger, 
                              DatabaseContext dbContext,
                              IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    } 
    
    /// <summary>
    /// Gets information.
    /// </summary>
    /// <returns>Some Text</returns>
    [Authorize]
    [HttpGet("")]
    public async Task<ActionResult<List<PropertyViewModel>>> Get()
    {
        var results = await _dbContext.Properties.ToListAsync();
        return Ok(_mapper.Map<List<Property>, List<PropertyViewModel>>(results));
    }

    [HttpPost]
    public async Task<ActionResult<PropertyViewModel>> CreateProperty(Property property)
    {
        await _dbContext.Properties.AddAsync(property);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManager.Db;
using PropertyManager.Models;
using PropertyManager.Utility;


namespace PropertyManager.Controllers;

[Authorize]
[Route("[controller]")]
public class PropertyController : Controller
#pragma warning restore CS1591
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
    
    [HttpGet("")]
    public async Task<ActionResult<List<PropertyViewModel>>> Get()
    {
        var results = await _dbContext.Properties.ToListAsync();
        return Ok(_mapper.Map<List<Property>, List<PropertyViewModel>>(results));
    }

    [HttpGet("New")]
    public IActionResult New()
    {
        return View();
    }
    
    [HttpPost("New")]
    public async Task<ActionResult<Property>> New([FromForm]CreatePropertyViewModel property)
    {
        if (ModelState.IsValid)
        {  
            var Mediea = new List<Media>();
            if (property.FormFiles != null && property.FormFiles.Count() > 0)
            {
                foreach (var propertyFormFile in property.FormFiles)
                {
                    var byteData = await StreamToByteArray(propertyFormFile.OpenReadStream());
                    Mediea.Add(new Media
                    {
                        Data = byteData,
                        MediaType = propertyFormFile.ContentType.Contains("image") ? MediaTypes.Photo : MediaTypes.Video,
                        FileType = System.IO.Path.GetExtension(propertyFormFile.FileName).Substring(1)
                    });
                }   
            }

            _dbContext.Properties.Add(new Property
            {
                Condition = property.Condition,
                Description = property.Description ?? "",
                Mediae = Mediea,
                Title = property.Title,
                CreatedOn = DateTime.Now,
                ResidentId = User.GetUserId()
            });
                
            await _dbContext.SaveChangesAsync();
            return Redirect("/");
        }
        return View();
    }
    
    [HttpGet("view/{propertyId:int}")]
    public async Task<ActionResult> ViewProperty(int propertyId)
    {
        return await _dbContext.Properties.Where(x => x.Id == propertyId).Include(p => p.Mediae).FirstAsync() switch
        {
            null => NotFound(),
            Property prop => View(prop)
        };
    }

    [HttpGet("edit/{id:int}")]
    public async Task<ActionResult> EditProperty(int id)
    {
        return await _dbContext.Properties.Where(x => x.Id == id).FirstAsync() switch
        {
            null => NotFound(),
            Property prop => View(new EditPropertyViewModel
            {
                Id = prop.Id,
                Condition = prop.Condition,
                Description = prop.Description,
                Title = prop.Title
            })
        };
    }

    [HttpPost("edit/{id:int}")]
    public async Task<ActionResult> EditProperty(int id, [FromForm]CreatePropertyViewModel property)
    {
        if (ModelState.IsValid)
        {
            var Mediea = new List<Media>();
            var extantProperty = _dbContext.Properties.Where(p => p.Id == id).FirstOrDefault();

            if (extantProperty != null)
            {
                foreach (var propertyFormFile in property.FormFiles)
                {
                    var byteData = await StreamToByteArray(propertyFormFile.OpenReadStream());
                    Mediea.Add(new Media
                    {
                        Data = byteData,
                        MediaType = propertyFormFile.ContentType.Contains("image") ? MediaTypes.Photo : MediaTypes.Video,
                        FileType = System.IO.Path.GetExtension(propertyFormFile.FileName).Substring(1)
                    });
                }

                _dbContext.Properties.Update(new Property
                {
                    Condition = property.Condition,
                    Description = property.Description ?? "",
                    Mediae = Mediea,
                    Title = property.Title,
                    CreatedOn = DateTime.Now,
                    ResidentId = User.GetUserId()
                });
                
                await _dbContext.SaveChangesAsync();
                return Redirect("/");   
            }

            return NotFound();
        }
        return View();
    }

    [HttpGet("delete/{id:int}")]
    public async Task<ActionResult> DeleteProperty(int id)
    {
        var prop = _dbContext.Properties.Where(p => p.Id == id).FirstOrDefault();
        if (prop != null)
        {
            _dbContext.Remove(prop);
            await _dbContext.SaveChangesAsync();
            return Redirect("/");
        }
        else
        {
            return NotFound();
        }
    }

    private async Task<byte[]> StreamToByteArray(Stream input)
    {
        MemoryStream ms = new MemoryStream();
        await input.CopyToAsync(ms);
        return ms.ToArray();
    }
}
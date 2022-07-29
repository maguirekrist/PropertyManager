using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertyManager.Db;
using PropertyManager.Models;
using PropertyManager.Utility;
using PropertyManager.Utility.Services;

namespace PropertyManager.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _dbContext;
    public HomeController(
        ILogger<HomeController> logger,
        DatabaseContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var alert = _dbContext.Alerts.FirstOrDefault();
        var resident = _dbContext.Residents.Where(res => res.Id == HttpContext.User.GetUserId())
            .Include(x => x.Properties).ThenInclude(x => x.Mediae).Include(x => x.Guests).FirstOrDefault();
        if (resident != null)
        {
            var vm = new IndexViewModel { Properties = resident.Properties.ToList(), Guests = resident.Guests.ToList(), ActiveAlert = alert};
            return View(vm);
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("guest/add")]
    public IActionResult AddGuest()
    {
        return View();
    }
    
    [HttpPost("guest/add")]
    public async Task<IActionResult> AddGuest(GuestViewModel guest)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Guests.Add(new Guest
            {
                Email = guest.Email,
                Password = guest.Password,
                CreatedOn = DateTime.Now,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                ResidentId = HttpContext.User.GetUserId()
            });
            await _dbContext.SaveChangesAsync();
            return Redirect("/");
        }

        return View();
    }

    [HttpGet("guest/remove/{id:int}")]
    public async Task<ActionResult> RemoveGuest(int id)
    {
        var guest = _dbContext.Guests.Where(x => x.Id == id).FirstOrDefault();
        if (guest != null)
        {
            _dbContext.Guests.Remove(guest);
            await _dbContext.SaveChangesAsync();
            return Redirect("/");
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("404")]
    public IActionResult Error404()
    {
        return View();
    }
}


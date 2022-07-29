using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertyManager.Db;
using PropertyManager.Models;

namespace PropertyManager.Controllers;


[Authorize(Roles = "Administrator")]
[Route("[controller]")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly DatabaseContext _dbContext;
    
    public AdminController(
        ILogger<AdminController> logger,
        DatabaseContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        var alert = _dbContext.Alerts.FirstOrDefault();
        var properties = _dbContext.Properties.Include(x => x.Resident).ToList();
        
        var vm = new AdminIndexViewModel
        {
            ActiveAlert = alert,
            Properties = properties,
        };
        return View(vm);
    }

    [HttpGet("alert/new")]
    public async Task<IActionResult> NewAlert()
    {
        return View();
    }

    [HttpPost("alert/new")]
    public async Task<IActionResult> NewAlert(Alert alert)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Alerts.Add(alert);
            await _dbContext.SaveChangesAsync();
            return Redirect("~/Admin/dashboard");
        }

        return View();
    }

    [HttpGet("alert/delete/{id:int}")]
    public async Task<IActionResult> DeleteAlert(int id)
    {
        var alert = _dbContext.Alerts.Where(x => x.Id == id).FirstOrDefault();
        if (alert != null)
        {
            _dbContext.Alerts.Remove(alert);
            await _dbContext.SaveChangesAsync();
            return Redirect("~/Admin/dashboard");
        }

        return NotFound();
    }
}
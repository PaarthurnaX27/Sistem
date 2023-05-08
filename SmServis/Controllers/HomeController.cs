using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmServis.Models;
using System.Web;


namespace SmServis.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult CıkısYap()
    {
        DataAccessLayer.Concrete.SmServisContext.data = null;
        HttpContext.Session.SetInt32("kullanici", 0);
        return RedirectToAction("Giris", "Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


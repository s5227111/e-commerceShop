using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using e_commerceProj.Models;

namespace e_commerceProj.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly productContext _context;

    public HomeController(ILogger<HomeController> logger, productContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Products.ToList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

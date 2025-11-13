using AdoptAMonsterSite.Data;
using AdoptAMonsterSite.Models;
using AdoptAMonsterSite.Models.ViewModels;
using AdoptAMonsterSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace AdoptAMonsterSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IMonsterQueryService _monsterQuery;

    public HomeController(
        ILogger<HomeController> logger, 
        ApplicationDbContext context,
        IMonsterQueryService monsterQuery)
    {
        _logger = logger;
        _context = context;
        _monsterQuery = monsterQuery;
    }

    public IActionResult Index()
    {

        var model = new HomeIndexViewModel
        {
            PopularMonsters = _monsterQuery.GetPopularMonsters(3),
            RecentMonsters = _monsterQuery.GetRecentMonsters(3)
        };

        return View(model);
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



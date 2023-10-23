using Microsoft.AspNetCore.Mvc;

namespace VendedoresMVC.Data;

public class Controller1 : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
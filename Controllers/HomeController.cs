using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Webapp.Controllers;

public class HomeController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Privacy()
    {
        return View();
    }  
 
    public IActionResult _LoginPartial()
    {
        return PartialView("~/Views/Shared/_LoginPartial.cshtml");
    }

    public IActionResult Account()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Agent()
    {
        return View();
    }
}

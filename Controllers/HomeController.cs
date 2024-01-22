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

     public IActionResult Contact()
    {
        return View();
    }

     [HttpPost]
    public IActionResult SubmitContact(string fullName, string email, string message)
    {
        // Process the submitted contact form data (e.g., send an email, save to database)

        // For simplicity, let's redirect back to the contact page
        return RedirectToAction("Contact");
    }
}

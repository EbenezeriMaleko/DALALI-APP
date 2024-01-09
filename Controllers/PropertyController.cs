// Controllers/PropertyController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Webapp.Models;
using Webapp.Data;

public class PropertyController : Controller
{
    private readonly ApplicationDbContext _context;

    public PropertyController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Agent()

    {
        return View();
    }

    [HttpPost]
    public IActionResult Agent(PropertyViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Convert IFormFile to byte[] for storing in the database
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(model.ImageData.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.ImageData.Length);
            }

            // Create a new product instance
            var newProperty = new Property
            {
                PropertyName = model.PropertyName,
                Description = model.Description,
                NumberOfBathrooms = model.NumberOfBathrooms,
                NumberOfBedrooms = model.NumberOfBedrooms,
                SquareFootage = model.SquareFootage,
                ImageData = imageData
            };

            // Add the product to the database
            _context.Properties.Add(newProperty);
            _context.SaveChanges();

             TempData["SuccessMessage"] = "Property details successfully saved.";

            return RedirectToAction("Index", "Home");  // Redirect to the home page or another view
        }

        return View(model);
    }
}
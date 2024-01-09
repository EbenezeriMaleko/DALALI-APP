namespace Webapp.Models;
public class Property
{
    public int PropertyId { get; set; }
    public string PropertyName { get; set; }
    public string Description { get; set; }
    public int NumberOfBedrooms { get; set; }
    public int NumberOfBathrooms { get; set; }
    public double SquareFootage { get; set; }

     public byte[] ImageData { get; set; }
     
}
public class PropertyViewModel
{
    public string PropertyName{get; set;}
    public string Description{get; set;}
    public int NumberOfBathrooms{get; set;}
    public int NumberOfBedrooms{get; set;}
    public double SquareFootage{get; set;}
    public IFormFile ImageData{get; set;}

}
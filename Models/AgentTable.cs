using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapp.Models;

public partial class AgentTable
{
    public int PropertyId { get; set; }

    public string Description { get; set; } = null!;

     [NotMapped]
    public IFormFile ImageFile{get; set;}
    
    public byte[] ImageData { get; set; } = null!;

    public int NumberOfBathrooms { get; set; }

    public int NumberOfBedrooms { get; set; }

    public string PropertyName { get; set; } = null!;

    public double SquareFootage { get; set; }
}

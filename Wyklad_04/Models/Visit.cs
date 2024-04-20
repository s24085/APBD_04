using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime DateOfVisit { get; set; }
    
    public int AnimalId { get; init; }
    public string? Description { get; set; }
    public double VisitPrice { get; set; }
}

namespace WebApplication1.Models.DTOs;

public class AnimalWithVisitDto
{
    public string Name { get; set; }
    public AnimalCategory AnimalCategory { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
    public DateTime VisitDate { get; set; }
    public string VisitDescription { get; set; }
    public double VisitPrice { get; set; }
}

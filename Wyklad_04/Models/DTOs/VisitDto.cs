using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Dtos;

public class VisitDto
{

    [Required]
    public int AnimalId { get; set; }  
    [Required]
    public DateTime VisitDate { get; }  
    [Required]
    [StringLength(500)]
    public required string VisitDescription { get; set; }

    [Range(0, double.MaxValue)]
    public double VisitPrice { get; }  
}

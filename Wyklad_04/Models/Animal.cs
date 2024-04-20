namespace WebApplication1.Models;

public class Animal{
    
        public string Name { get; set; }
        public int Id { get; set; }
        public AnimalCategory AnimalCategory { get; set;  }
        public double Weight { get; set; }
        public string FurColor { get; set; }
    }
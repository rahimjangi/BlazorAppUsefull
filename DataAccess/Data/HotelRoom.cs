using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data;

public class HotelRoom
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int Occupancy { get; set; }
    [Required]
    public double RegularRate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SqFt { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreateDay { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; } = string.Empty;
    public DateTime UpdatedDate { get; set; }
}

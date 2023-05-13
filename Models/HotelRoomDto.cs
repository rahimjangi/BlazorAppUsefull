using System.ComponentModel.DataAnnotations;

namespace Models;

public class HotelRoomDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int Occupancy { get; set; }
    [Required]
    public double RegularRate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SqFt { get; set; } = string.Empty;
}

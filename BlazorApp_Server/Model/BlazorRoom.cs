using System.ComponentModel.DataAnnotations;

namespace BlazorApp_Server.Model;

public class BlazorRoom
{
    public int Id { get; set; }
    [Display(Name = "Room Name")]
    public string RoomName { get; set; } = string.Empty;
    public double Price { get; set; }
    public bool IsActive { get; set; }
    public List<BlazorRoomProp> RoomProps { get; set; } = new List<BlazorRoomProp>();
}

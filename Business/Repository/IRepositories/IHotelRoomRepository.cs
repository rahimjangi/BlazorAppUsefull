using Models;

namespace Business.Repository.IRepositories;

public interface IHotelRoomRepository
{
    Task<HotelRoomDto> CreateHootelRoom(HotelRoomDto hotelRoomDto);
    Task<HotelRoomDto> UpdateHootelRoom(int roomId, HotelRoomDto hotelRoomDto);
    Task<HotelRoomDto> GetHootelRoom(int roomId);
    Task<IEnumerable<HotelRoomDto>> GetAllHootelRooms();
    Task DeleteHootelRoom(HotelRoomDto hotelRoomDto);
    Task<bool> IsSameRoomPresent(string name);

}

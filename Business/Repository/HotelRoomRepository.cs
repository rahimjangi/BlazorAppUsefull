using AutoMapper;
using Business.Repository.IRepositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository;

public class HotelRoomRepository : IHotelRoomRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<HotelRoomDto> CreateHootelRoom(HotelRoomDto hotelRoomDto)
    {
        HotelRoom hotelRoom = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto);
        hotelRoom.CreateDay = DateTime.Now;
        hotelRoom.CreatedBy = "Rahim";
        var savedHotelRoom = await _db.AddAsync(hotelRoom);
        await _db.SaveChangesAsync();
        HotelRoomDto hotelRoomDtoFromDb = _mapper.Map<HotelRoom, HotelRoomDto>(savedHotelRoom.Entity);
        return hotelRoomDtoFromDb;

    }

    public async Task DeleteHootelRoom(HotelRoomDto hotelRoomDto)
    {
        var hotelRoomFramDb = await _db.HotelRooms.FindAsync(hotelRoomDto.Id);
        if (hotelRoomFramDb == null) throw new Exception("Room does not exis");
        _db.HotelRooms.Remove(hotelRoomFramDb);
    }

    public async Task<IEnumerable<HotelRoomDto>> GetAllHootelRooms()
    {
        var hotelRoomsAsync = await _db.HotelRooms.ToListAsync();
        var hotelRoomDtos = _mapper.Map<List<HotelRoom>, List<HotelRoomDto>>(hotelRoomsAsync);
        return hotelRoomDtos;
    }

    public async Task<HotelRoomDto> GetHootelRoom(int roomId)
    {
        var hotelRoomFramDb = await _db.HotelRooms.FindAsync(roomId);
        if (hotelRoomFramDb == null) { throw new Exception("Entity does not exist"); }
        HotelRoomDto hotelRoomDto = _mapper.Map<HotelRoom, HotelRoomDto>(hotelRoomFramDb);
        return hotelRoomDto;
    }

    public async Task<bool> IsSameRoomPresent(string name)
    {
        var hotelRoomFromDb = await _db.HotelRooms.FirstAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        return hotelRoomFromDb != null;
    }

    public async Task<HotelRoomDto> UpdateHootelRoom(int roomId, HotelRoomDto hotelRoomDto)
    {
        var hotelRoomFramDb = await _db.HotelRooms.FindAsync(roomId);
        if (hotelRoomFramDb == null) throw new Exception("Entity does not exist");

        hotelRoomFramDb.Name = hotelRoomDto.Name;
        hotelRoomFramDb.Occupancy = hotelRoomDto.Occupancy;
        hotelRoomFramDb.UpdatedDate = DateTime.Now;
        hotelRoomFramDb.Description = hotelRoomDto.Description;

        _db.Update(hotelRoomFramDb);
        _db.SaveChanges();
        HotelRoomDto updatedHotelRoomDto = _mapper.Map<HotelRoom, HotelRoomDto>(hotelRoomFramDb);
        return updatedHotelRoomDto;
    }
}

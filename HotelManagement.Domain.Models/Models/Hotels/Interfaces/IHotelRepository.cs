namespace HotelManagement.Domain.Models.Models.Hotels.Interfaces
{
    public interface IHotelRepository
    {
        void Add(Hotel hotel);
        void Update(Hotel hotel);
    }
}
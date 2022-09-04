namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class RegisterHotelDto
    {
        public string Name { get; set; }

        public int Stars { get; set; }

        public string City { get; set; }

        public string AddressDetails { get; set; }
    }
}
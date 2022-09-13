using System.Collections.Generic;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelWithPictureDto : HotelDto
    {
        public HotelWithPictureDto(List<HotelPictureDto> hotelPictureDtos)
        {
            HotelPictureDtos = hotelPictureDtos;
        }

        public List<HotelPictureDto> HotelPictureDtos { get; private set; } = new();

    }
}
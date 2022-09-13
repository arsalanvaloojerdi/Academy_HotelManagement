using System.Collections.Generic;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelWithFacilityDto : HotelDto
    {
        public HotelWithFacilityDto(List<HotelFacilityDto> hotelFacilityDto)
        {
            HotelFacilityDto = hotelFacilityDto;
        }

        public List<HotelFacilityDto> HotelFacilityDto { get; private set; } = new();

    }
}
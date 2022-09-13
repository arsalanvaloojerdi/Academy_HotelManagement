using HotelManagement.Application.Interfaces.Hotels.Dtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace HotelManagement.Application.Interfaces.Hotels
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllHotelsAsync();

        Task<HotelDetailsDto> GetHotelDetailsAsync(Guid id);

        Task RegisterHotelAsync(RegisterHotelDto dto);

        Task ModifyHotelAsync(ModifyHotelDto dto);

        Task AddFacilityAsync(AddFacilityDto dto);

        Task<HotelImagesDto> GetImagesAsync(Guid id);

        Task AddImageAsync(AddHotelImageDto dto);
    }
}
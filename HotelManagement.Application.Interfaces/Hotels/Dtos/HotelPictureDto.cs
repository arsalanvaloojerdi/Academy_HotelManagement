namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelPictureDto
    {
        public HotelPictureDto(string name, string fileUrl)
        {
            this.Name = name;
            this.FileUrl = fileUrl;
        }

        public string Name { get; private set; }
        public string FileUrl { get; private set; }

    }
}
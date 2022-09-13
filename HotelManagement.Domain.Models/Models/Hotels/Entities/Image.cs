namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class Image
    {
        public Image(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}

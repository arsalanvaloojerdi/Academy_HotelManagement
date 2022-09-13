namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public  class Address
    {
        public Address(string city, string details)
        {
            this.City = city;
            this.Details = details;
        }

        public string City { get; private set; }

        public string Details { get; private set; }
    }
}
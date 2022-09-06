namespace HotelManagement.Api.Host.SeedWorks
{
    public class ApiResponseModel<T>
    {
        public ApiResponseModel()
        {

        }

        public ApiResponseModel(string message, T content)
        {
            this.Message = message;
            this.Content = content;
        }

        public string Message { get; set; }

        public T Content { get; set; }

        public ApiResponseModelError ErrorInfo { get; set; }
    }

    public class ApiResponseModelError
    {
        public int Code { get; set; }

        public string Details { get; set; }
    }
}
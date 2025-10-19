namespace Application.Utils.ApiResponse
{
    public class ApiDataResponse<TData> : ApiResponse
    {
        public TData? Data { get; set; }

        public ApiDataResponse(bool success, TData? data) : base(success)
        {
            this.Data = data;
        }
        public ApiDataResponse(bool success, TData? data, string? message) : base(success, message)
        {
            this.Data = data;
        }

        public ApiDataResponse(bool success, TData? data, string? message, List<string>? errors) : base(success, message, errors)
        {
            this.Data = data;
        }
    }
}

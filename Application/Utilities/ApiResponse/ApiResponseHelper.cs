namespace Application.Utils.ApiResponse
{
    public static class ApiResponseHelper
    {
        public static ApiResponse Success(string? message = null)
            => new ApiResponse(true, message);
        public static ApiDataResponse<TData> Success<TData>(string? message = null, 
                                                            TData ? data = default)
            => new ApiDataResponse<TData>(true, data, message);


        public static ApiResponse Error(string? message = null, 
                                        List<string>? errors = null)
            => new ApiResponse(false, message, errors);
        public static ApiDataResponse<TData> Error<TData>(string? message = null, 
                                                          TData? data = default, 
                                                          List<string>? errors = null)
            => new ApiDataResponse<TData>(false, data, message, errors);
    }
}

using TaskFlow.API.Responses;

namespace TaskFlow.API.Helpers
{
    public static class ApiResponseHelper
    {
        public static ApiResponse<T> Success<T>(T data)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = "Success"
            };
        }

        public static ApiResponse<T> Success<T>(T data, string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }
        public static ApiResponse<T> Fail<T>(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message
            };
        }
        public static ApiResponse<T> Fail<T>(string message, T data)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Data = data,
                Message = message
            };
        }
    }
}

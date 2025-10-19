using Core.Utilities.ResultTool.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils.ApiResponse
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

        public ApiResponse(bool success)
        {
            Success = success;
        }

        public ApiResponse(bool success, string? message) : this(success)
        {
            Message = message;
        }

        public ApiResponse(bool success, string? message, List<string>? errors) : this(success, message)
        {
            Errors = errors;
        }
    }
}

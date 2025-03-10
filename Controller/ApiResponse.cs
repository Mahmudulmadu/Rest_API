using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeStamp { get; set; }

        private ApiResponse(bool success, string message, T? data, List<string>? errors, int statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
            StatusCode = statusCode;
            TimeStamp = DateTime.UtcNow;
        }

        public static ApiResponse<T> SuccessResponse(T? data, int statusCode, string message="")
        {

            return new ApiResponse<T>(true, message, data, null, statusCode);

        }

        public static ApiResponse<T> ErrorResponse(List<string>?errors, int statusCode, string message="")
        {

            return new ApiResponse<T>(false, message, default(T), errors, statusCode);

        }

    }
}
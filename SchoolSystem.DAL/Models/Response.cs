using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Models
{
    public class Response<T>(T? data, string message = "opreation done", string? errors = null, bool sucesse = true)
    {
        public bool Success { get; set; } = sucesse;
        public string message { get; set; } = message;
        public string? errors { get; set; } = errors;
        public T? data { get; set; } = data;
    }

    public class ApiResponse<T>(T? data, string? errors = null, string message = "opreation done",  bool sucesse = true, string codestate = "200")
    {
        public bool Success { get; set; } = sucesse;
        public string Codestate { get; set; } = codestate;
        public string message { get; set; } = message;
        public string? errors { get; set; } = errors;
        public T? Data { get; set; } = data;
    }

    public class ApiResponse2(string? data = null, string? errors = null, string message = "Validation errors occurred", bool sucesse = true, string codestate = "400")
    {
        public bool Success { get; set; } = sucesse;
        public string Codestate { get; set; } = codestate;
        public string message { get; set; } = message;
        public string? errors { get; set; } = errors;
        public string? data { get; set; } = data;
    }

    public class ApiResponse3(string? data = null, string? errors = null, string message = "User data is missing", bool sucesse = true, string codestate = "400")
    {
        public bool Success { get; set; } = sucesse;
        public string Codestate { get; set; } = codestate;
        public string message { get; set; } = message;
        public string? errors { get; set; } = errors;
        public string? data { get; set; } = data;
    }



    public class ApiResponse4(string? data = null, string? errors = null, string message = "Internal server error occurred", bool sucesse = false, string codestate = "500")
    {
        public bool Success { get; set; } = sucesse;
        public string Codestate { get; set; } = codestate;
        public string message { get; set; } = message;
        public string? errors { get; set; } = errors;
        public string? data { get; set; } = data;
    }

    public class ApiResponse5<T>(T? data, string? errors = null, string message = "created successfully", bool sucesse = true, string codestate = "201")
    {
        public bool Success { get; set; } = sucesse;
        public string Codestate { get; set; } = codestate;
        public string message { get; set; } = message;
        public string? errors { get; set; } = errors;
        public T? data { get; set; } = data;
    }

    public class ApiResponse6<T>(T? data, string? errors = null, string message = "retrieved successfully", bool sucesse = true, string codestate = "200")
    {
        public bool Success { get; set; } = sucesse;
        public string Codestate { get; set; } = codestate;
        public string Message { get; set; } = message;
        public string? Errors { get; set; } = errors;
        public T? Data { get; set; } = data;
    }


}

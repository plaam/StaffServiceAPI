using System.Text.Json;

namespace StaffServiceAPI.Dto;

public class ErrorDto
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}
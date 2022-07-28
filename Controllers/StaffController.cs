using Microsoft.AspNetCore.Mvc;
using StaffServiceAPI.Services;

namespace StaffServiceAPI.Controllers;

[ApiController, Route("[controller]")]
public class StaffController : ControllerBase
{
    private readonly ILogger<StaffController> _logger;
    private readonly IStaffRepository _staffRepository;

    public StaffController(ILogger<StaffController> logger, IStaffRepository staffRepository)
    {
        _logger = logger;
        _staffRepository = staffRepository;
    }

    [HttpGet("employees")]
    public IActionResult GetEmployees() => Ok(_staffRepository.GetEmployees());

    [HttpGet("joe")]
    public IActionResult GetJoe() => Ok(_staffRepository.LoadJoe());
}

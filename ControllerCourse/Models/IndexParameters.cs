using Microsoft.AspNetCore.Mvc;

namespace ControllerCourse.Models;

public class IndexParameters
{
    [FromBody]
    public int? PageId { get; set; }
    [FromQuery]
    public string? SearchBy { get; set; }
}
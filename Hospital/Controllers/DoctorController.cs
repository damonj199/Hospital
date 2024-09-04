using Hospital.Bll.IService;
using Hospital.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[ApiController]
[Route("/api/doctors/")]
public class DoctorController : Controller
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> RegisterDoctorAsync(DoctorDto doctor)
    {
        await _doctorService.AddDoctorAsync(doctor);

        return Ok(doctor.Id);
    }

    [HttpDelete("by-id/{id}")]
    public async Task<ActionResult> DeleteDoctorAsync(Guid id)
    {
        DoctorDto doctor = await _doctorService.GetDoctorBiIdAsync(id);
        await _doctorService.DeleteDoctorAsync(doctor);

        return Ok();
    }

    [HttpPut("by-id/{id}")]
    public async Task<ActionResult> UpdateDoctorByIdAsync(Guid id, DoctorDto doctor)
    {
        await _doctorService.UpdateDoctorAsync(id, doctor);

        return Ok();
    }

    [HttpGet("by-id/{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctorByIdAsync(Guid id)
    {
        var doc = await _doctorService.GetDoctorBiIdAsync(id);

        return Ok(doc);
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<DoctorDto>>> GetDoctorsListAsync(string sortBy = "Name", int page = 1, int pageSize = 10)
    {
        var doctors = await _doctorService.GetDoctorsListAsync(sortBy, page, pageSize);

        return Ok(doctors);
    }
}

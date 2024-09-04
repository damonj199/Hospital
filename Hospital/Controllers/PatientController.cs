using Hospital.Bll.IService;
using Hospital.Bll.Service;
using Hospital.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;

[ApiController]
[Route("/api/patients")]
public class PatientController : Controller
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> RegisterPatientAsync(PatientDto patient)
    {
        await _patientService.AddPatientAsync(patient);

        return Ok(patient.Id);
    }

    [HttpDelete("/by-id/{id}")]
    public async Task<ActionResult> DeletePatientAsync(Guid id)
    {
        var patient = await _patientService.GetPatientBiIdAsync(id);
        await _patientService.DeletePatientAsync(patient);

        return Ok();
    }

    //[HttpPut("/by-id/{id}")]
    //public async Task<ActionResult> UpdatePatientByIdAsync(Guid id, PatientDto patient)
    //{
    //    await _patientService.UpdatePatientAsync(id, patient);

    //    return Ok();
    //}

    //[HttpGet("/by-id/{id}")]
    //public async Task<ActionResult<PatientDto>> GetPatientByIdAsync(Guid id)
    //{
    //    var patient = await _patientService.GetPatientBiIdAsync(id);

    //    return Ok(patient);
    //}

    //[HttpGet("/list-doctors")]
    //public async Task<ActionResult<List<PatientDto>>> GetPatientsListAsync(string sortBy = "Name", int page = 1, int pageSize = 10)
    //{
    //    var patients = await _patientService.GetPatientsListAsync(sortBy, page, pageSize);

    //    return Ok(patients);
    //}
}

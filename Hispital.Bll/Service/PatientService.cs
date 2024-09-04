using Hospital.Bll.IService;
using Hospital.Core.Dtos;
using Hospital.Dal.IRepository;
using Hospital.Dal.Repository;

namespace Hospital.Bll.Service;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Guid> AddPatientAsync(PatientDto patient)
    {
        await _patientRepository.AddPatientAsync(patient);

        return patient.Id;
    }

    public async Task DeletePatientAsync(PatientDto patient)
    {
        await _patientRepository.DeletePatientAsync(patient);
    }

    public async Task<PatientDto> GetPatientBiIdAsync(Guid id)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(id);

        return patient;
    }

    public async Task UpdatePatientAsync(Guid id, PatientDto patient)
    {
        await _patientRepository.UpdatePatientAsync(id, patient);
    }

    public async Task<List<PatientDto>> GetPatientsListAsync(string sortBy = "Name", int page = 1, int pageSize = 10)
    {
        var patients = await _patientRepository.CetPatientsListAsync(sortBy, page, pageSize);

        return patients;
    }
}

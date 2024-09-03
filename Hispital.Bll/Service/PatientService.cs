using Hospital.Bll.IService;
using Hospital.Core.Dtos;
using Hospital.Dal.IRepository;

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
}

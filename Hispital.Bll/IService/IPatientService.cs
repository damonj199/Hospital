using Hospital.Core.Dtos;

namespace Hospital.Bll.IService;

public interface IPatientService
{
    Task<Guid> AddPatientAsync(PatientDto patient);
    Task DeletePatientAsync(PatientDto patient);
}

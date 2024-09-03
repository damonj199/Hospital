using Hospital.Core.Dtos;

namespace Hospital.Dal.IRepository;

public interface IPatientRepository
{
    Task<Guid> AddPatientAsync(PatientDto patient);
    Task DeletePatientAsync(PatientDto patient);
}

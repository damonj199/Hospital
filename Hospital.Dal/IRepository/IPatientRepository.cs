using Hospital.Core.Dtos;

namespace Hospital.Dal.IRepository;

public interface IPatientRepository
{
    Task<Guid> AddPatientAsync(PatientDto patient);
    Task DeletePatientAsync(PatientDto patient);
    Task<PatientDto> GetPatientByIdAsync(Guid id);
    //Task UpdatePatientAsync(Guid id, PatientDto patient);
    //Task<List<PatientDto>> CetPatientsListAsync(string sortBy = "Name", int page = 1, int pageSize = 10);
}

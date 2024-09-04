using Hospital.Core.Dtos;

namespace Hospital.Bll.IService;

public interface IPatientService
{
    Task<Guid> AddPatientAsync(PatientDto patient);
    Task DeletePatientAsync(PatientDto patient);
    Task<PatientDto> GetPatientBiIdAsync(Guid id);
    Task<List<PatientDto>> GetPatientsListAsync(string sortBy = "Name", int page = 1, int pageSize = 10);
    Task UpdatePatientAsync(Guid id, PatientDto patient);
}

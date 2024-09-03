using Hospital.Core.Dtos;

namespace Hospital.Bll.IService;

public interface IDoctorService
{
    Task<Guid> AddDoctorAsync(DoctorDto doctor);
    Task DeleteDoctorAsync(DoctorDto doctor);
    Task<DoctorDto> GetDoctorBiIdAsync(Guid id);
    Task UpdateDoctorAsync(Guid id, DoctorDto doctor);
}

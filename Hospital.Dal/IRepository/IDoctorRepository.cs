using Hospital.Core.Dtos;

namespace Hospital.Dal.IRepository;

public interface IDoctorRepository
{
    Task<Guid> AddDoctorAsync(DoctorDto doctor);
    Task DeleteDoctorAsync(DoctorDto doctor);
    Task<DoctorDto> GetDoctorByIdAsync(Guid id);
    Task UpdateDoctorAsync(Guid id, DoctorDto doctor);
}

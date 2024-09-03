using Hospital.Bll.IService;
using Hospital.Core.Dtos;
using Hospital.Dal.IRepository;

namespace Hospital.Bll.Service;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Guid> AddDoctorAsync(DoctorDto doctor)
    {
        await _doctorRepository.AddDoctorAsync(doctor);

        return doctor.Id;
    }

    public async Task DeleteDoctorAsync(DoctorDto doctor)
    {
        await _doctorRepository.DeleteDoctorAsync(doctor);
    }

    public async Task<DoctorDto> GetDoctorBiIdAsync(Guid id)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

        return doctor;
    }

    public async Task UpdateDoctorAsync(Guid id, DoctorDto doctor)
    {
        await _doctorRepository.UpdateDoctorAsync(id, doctor);
    }
}

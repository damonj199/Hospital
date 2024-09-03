using Hospital.Core.Dtos;
using Hospital.Dal.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Dal.Repository;

public class DoctorRepository : BaseRepository, IDoctorRepository
{
    public DoctorRepository(HospitalDbContext connectionSrting) : base(connectionSrting)
    {
    }

    public async Task<Guid> AddDoctorAsync(DoctorDto doctor)
    {
        await _ctx.Doctors.AddAsync(doctor);
        await _ctx.SaveChangesAsync();

        return doctor.Id;
    }

    public async Task DeleteDoctorAsync(DoctorDto doctor)
    {
        _ctx.Doctors.Remove(doctor);
        await _ctx.SaveChangesAsync();
    }

    public async Task<DoctorDto> GetDoctorByIdAsync(Guid id)
    {
        var doctor = await _ctx.Doctors
            .FirstOrDefaultAsync(d => d.Id == id);

        return doctor;
    }

    public async Task UpdateDoctorAsync(Guid id, DoctorDto doctor)
    {
        var doc = _ctx.Doctors.Find(id);

        doc.Id = id;
        doc.Name = doctor.Name;
        doc.Surname = doctor.Surname;
        doc.Patronymic = doctor.Patronymic;
        doc.Office = doctor.Office;
        doc.Specialization = doctor.Specialization;
        doc.Sector = doctor.Sector;

        await _ctx.SaveChangesAsync();
    }
}

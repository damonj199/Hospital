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

    public async Task<List<DoctorDto>> CetDoctorsListAsync(string sortBy = "Name", int page = 1, int pageSize = 10)
    {
        var doctors = _ctx.Doctors.AsQueryable();

        switch (sortBy.ToLower())
        {
            case "name":
                doctors = doctors.OrderBy(d => d.Name);
                break;
            case "surname":
                doctors = doctors.OrderBy(d => d.Surname);
                break;
            case "patronymic":
                doctors = doctors.OrderBy(d => d.Patronymic);
                break;
            case "office":
                doctors = doctors.OrderBy(d => d.Office);
                break;
            case "specialization":
                doctors = doctors.OrderBy(d => d.Specialization);
                break;
            case "sector":
                doctors = doctors.OrderBy(d => d.Sector);
                break;

            default:
                doctors = doctors.OrderBy(d => d.Name);
                break;
        }

        var pagedDoctors = doctors.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return pagedDoctors;
    }
}

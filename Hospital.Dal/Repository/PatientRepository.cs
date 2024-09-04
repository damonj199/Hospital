using Hospital.Core.Dtos;
using Hospital.Dal.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Dal.Repository;

public class PatientRepository : BaseRepository, IPatientRepository
{
    public PatientRepository(HospitalDbContext connectionSrting) : base(connectionSrting)
    {
    }

    public async Task<Guid> AddPatientAsync(PatientDto patient)
    {
        await _ctx.Patients.AddAsync(patient);
        await _ctx.SaveChangesAsync();

        return patient.Id;
    }

    public async Task DeletePatientAsync(PatientDto patient)
    {
        _ctx.Patients.Remove(patient);
        await _ctx.SaveChangesAsync();
    }

    public async Task<PatientDto> GetPatientByIdAsync(Guid id)
    {
        var patient = await _ctx.Patients
            .FirstOrDefaultAsync(d => d.Id == id);

        return patient;
    }

    public async Task UpdatePatientAsync(Guid id, PatientDto patient)
    {
        var pat = _ctx.Patients.Find(id);

        pat.Id = id;
        pat.Name = patient.Name;
        pat.Surname = patient.Surname;
        pat.Patronymic = patient.Patronymic;
        pat.Address = patient.Address;
        pat.DateOfBirth = patient.DateOfBirth;
        pat.Sector = patient.Sector;

        await _ctx.SaveChangesAsync();
    }

    public async Task<List<PatientDto>> CetPatientsListAsync(string sortBy = "Name", int page = 1, int pageSize = 10)
    {
        var patients = _ctx.Patients.AsQueryable();

        switch (sortBy.ToLower())
        {
            case "name":
                patients = patients.OrderBy(d => d.Name);
                break;
            case "surname":
                patients = patients.OrderBy(d => d.Surname);
                break;
            case "patronymic":
                patients = patients.OrderBy(d => d.Patronymic);
                break;
            case "office":
                patients = patients.OrderBy(d => d.Address);
                break;
            case "specialization":
                patients = patients.OrderBy(d => d.DateOfBirth);
                break;
            case "sector":
                patients = patients.OrderBy(d => d.Sector);
                break;

            default:
                patients = patients.OrderBy(d => d.Name);
                break;
        }

        var pagedPatiens = patients.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return pagedPatiens;
    }
}

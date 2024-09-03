using Hospital.Core.Dtos;
using Hospital.Dal.IRepository;

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
}

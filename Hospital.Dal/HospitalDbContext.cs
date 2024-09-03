using Hospital.Core.Dtos;
using Hospital.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Dal;

public class HospitalDbContext : DbContext
{
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

    public DbSet<DoctorDto> Doctors { get; set; }
    public DbSet<OfficeDto> Office { get; set; }
    public DbSet<PatientDto> Patients { get; set; }
    public DbSet<SectorDto> Sectors { get; set; }
    public DbSet<SpecializationDto> Specializations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientDto>()
            .Property(x => x.Gender)
            .HasConversion(
                a => a.ToString(),
                a => (Gender)Enum.Parse(typeof(Gender), a));
    }
}

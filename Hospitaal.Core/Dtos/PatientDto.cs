using Hospital.Core.Enums;

namespace Hospital.Core.Dtos;

public class PatientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public SectorDto Sector { get; set; }
}

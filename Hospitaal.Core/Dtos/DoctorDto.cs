namespace Hospital.Core.Dtos;

public class DoctorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public OfficeDto Office { get; set; }
    public SpecializationDto Specialization { get; set; }
    public SectorDto? Sector { get; set; }
}

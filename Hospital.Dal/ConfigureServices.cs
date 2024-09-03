using Hospital.Dal.IRepository;
using Hospital.Dal.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Dal;

public static class ConfigureServices
{
    public static void ConfigureDalServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
    }
}

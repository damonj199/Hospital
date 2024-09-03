using Hospital.Bll.IService;
using Hospital.Bll.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Bll;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
    }
}

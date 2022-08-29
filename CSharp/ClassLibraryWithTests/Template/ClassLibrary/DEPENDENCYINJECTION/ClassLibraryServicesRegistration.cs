namespace $ext_safeprojectname$.DependencyInjection;

public static class $ext_safeprojectname$ServicesRegistration
{
    public static IServiceCollection Add$ext_safeprojectname$Services(this IServiceCollection services)
    {
        services.TryAddScoped<IPersonService, PersonService>();
        return services;
    }
}
namespace ClassLibrary.DependencyInjection;

public static class ClassLibraryServicesRegistration
{
    public static IServiceCollection AddClassLibraryServices(this IServiceCollection services)
    {
        services.TryAddScoped<IPersonService, PersonService>();
        return services;
    }
}
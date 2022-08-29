namespace ClassLibrary.DependencyInjection;

public class ClassLibraryServicesRegistrationTests
{
    [Fact]
    public void ClassLibraryServicesRegistration_AddClassLibraryServices_AddsServices()
    {
        var loggerSpy = new LoggerSpy<PersonService>();
        var fakeLoggerFactory = Substitute.For<ILoggerFactory>();
        fakeLoggerFactory.CreateLogger(Arg.Any<string>()).Returns(loggerSpy);

        var services = new ServiceCollection();
        services.AddSingleton<ILoggerFactory>(fakeLoggerFactory);

        var result = services.AddClassLibraryServices();

        result.Should().BeSameAs(services);
        var provider = services.BuildServiceProvider();
        var scope = provider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IPersonService>();
        service.Should().BeOfType<PersonService>();
    }
}
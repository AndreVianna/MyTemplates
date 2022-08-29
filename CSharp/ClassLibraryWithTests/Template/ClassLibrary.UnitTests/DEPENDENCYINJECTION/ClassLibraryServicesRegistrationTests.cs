namespace $ext_safeprojectname$.DependencyInjection;
    
public class $ext_safeprojectname$ServicesRegistrationTests
{
    [Fact]
    public void $ext_safeprojectname$Registration_Add$ext_safeprojectname$Services_AddsServices()
    {
        var loggerSpy = new LoggerSpy<PersonService>();
        var fakeLoggerFactory = Substitute.For<ILoggerFactory>();
        fakeLoggerFactory.CreateLogger(Arg.Any<string>()).Returns(loggerSpy);

        var services = new ServiceCollection();
        services.AddSingleton<ILoggerFactory>(fakeLoggerFactory);

        var result = services.Add$ext_safeprojectname$Services();

        result.Should().BeSameAs(services);
        var provider = services.BuildServiceProvider();
        var scope = provider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IPersonService>();
        service.Should().BeOfType<PersonService>();
    }
}
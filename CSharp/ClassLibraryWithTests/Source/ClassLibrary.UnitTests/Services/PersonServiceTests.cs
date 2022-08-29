namespace ClassLibrary.Services;

public class PersonServiceTests
{
    private readonly ILoggerFactory _fakeLoggerFactory;
    private readonly LoggerSpy<PersonService> _loggerSpy;

    public PersonServiceTests()
    {
        _loggerSpy = new LoggerSpy<PersonService>();
        _fakeLoggerFactory = Substitute.For<ILoggerFactory>();
        _fakeLoggerFactory.CreateLogger(Arg.Any<string>()).Returns(_loggerSpy);
    }

    [Fact]
    public void PersonService_Salute_LogsSalutation()
    {
        var personFaker = new AutoFaker<Person>();
        var person = personFaker.Generate();


        var subject = new PersonService(_fakeLoggerFactory);

        subject.Salute(person);

        _loggerSpy.Logs.Should().HaveCount(1);
        _loggerSpy.Logs[0].Should().Be($"Hello {person.FirstName}!");
    }

    [Fact]
    public void PersonService_Salute_WithNullPerson_Throws()
    {
        var subject = new PersonService(_fakeLoggerFactory);

        [ExcludeFromCodeCoverage(Justification = "Forced exception.")]
        void InvalidCall() => subject.Salute(null!);

        var action = InvalidCall;

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void PersonService_GetFullName_ReturnsName()
    {
        var personFaker = new AutoFaker<Person>();
        var person = personFaker.Generate();


        var subject = new PersonService(_fakeLoggerFactory);

        var result = subject.GetFullName(person);

        _loggerSpy.Logs.Should().BeEmpty();
        result.Should().Be($"{person.FirstName} {person.LastName}");
    }

    [Fact]
    public void PersonService_GetFullName_WithNullPerson_Throws()
    {
        var subject = new PersonService(_fakeLoggerFactory);

        [ExcludeFromCodeCoverage(Justification = "Forced exception.")]
        void InvalidCall() => subject.GetFullName(null!);

        var action = InvalidCall;

        action.Should().Throw<ArgumentNullException>();
    }
}
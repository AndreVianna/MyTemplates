namespace ClassLibrary.Services;

public class PersonService : IPersonService
{
    private readonly ILogger<PersonService> _logger;

    public PersonService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<PersonService>();
    }

    public string GetFullName(Person person)
    {
        ArgumentNullException.ThrowIfNull(person, nameof(person));
        return $"{person.FirstName} {person.LastName}";
    }

    public void Salute(Person person)
    {
        ArgumentNullException.ThrowIfNull(person, nameof(person));
        _logger.LogInformation("Hello {personName}!", person.FirstName);
    }
}

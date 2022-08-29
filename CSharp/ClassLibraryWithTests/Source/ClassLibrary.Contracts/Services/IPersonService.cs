namespace ClassLibrary.Services;

public interface IPersonService
{
    void Salute(Person person);
    string GetFullName(Person person);
}
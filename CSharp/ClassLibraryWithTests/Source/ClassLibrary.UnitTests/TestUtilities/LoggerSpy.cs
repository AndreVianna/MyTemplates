namespace ClassLibrary.TestUtilities;

[ExcludeFromCodeCoverage(Justification = "Internal test class.")]
internal class LoggerSpy<T> : ILogger<T>
{
    public IList<string> Logs { get; } = new List<string>();

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        Logs.Add(formatter(state, exception));
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();
}
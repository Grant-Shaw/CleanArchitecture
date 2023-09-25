namespace ExampleApi.Application.Common.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}

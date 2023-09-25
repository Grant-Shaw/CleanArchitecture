using ExampleApi.Application.Common.Services;

namespace ExampleApi.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

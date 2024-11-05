using CruiseManager.Shared.Abstractions;

namespace CruiseManager.Shared.Infrastructure.Time;

internal class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.Now;
}
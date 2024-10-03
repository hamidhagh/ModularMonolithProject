using MediatR;

namespace BookStore.SharedKernel;

public abstract record IntegrationEventBase : INotification
{
  public DateTimeOffset DateTimeOffset { get; set; } = DateTimeOffset.UtcNow;
}


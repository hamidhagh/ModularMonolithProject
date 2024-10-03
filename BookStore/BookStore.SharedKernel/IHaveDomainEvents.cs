namespace BookStore.SharedKernel;

public interface IHaveDomainEvents
{
  IEnumerable<DomainEventBase> DomainEvents { get; }
  void ClearDomainEvents();
}


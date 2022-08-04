using System;
using MassTransit;

namespace ShoppingEvents;

public interface OrderSubmitted : CorrelatedBy<Guid>
{
    public Guid CorrelationId { get; }
}
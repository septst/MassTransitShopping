using System;
using MassTransit;

namespace ShoppingEvents;

public interface CheckOrder : CorrelatedBy<Guid>
{
    public Guid CorrelationId { get; }
    public Guid OrderId { get; }
}
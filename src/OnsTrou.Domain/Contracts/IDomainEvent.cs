using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Contracts;

public interface IDomainEvent : INotification
{
    public Guid Id { get; set; }
}
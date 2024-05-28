using EasyCompany.GenericResult.Core;
using OnsTrou.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;

public record CreateWeddingCommand() : ICommand<Guid>;

internal sealed class CreateWeddingCommandHandler : ICommandHandler<CreateWeddingCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateWeddingCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1);
        return Guid.NewGuid();
    }
}
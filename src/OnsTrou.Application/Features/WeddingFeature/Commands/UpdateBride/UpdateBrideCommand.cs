using EasyCompany.GenericResult.Core;
using OnsTrou.Application.Abstractions;
using OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;
using OnsTrou.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.WeddingFeature.Commands.UpdateBride
{
    public record UpdateBrideCommand(string Name, string Surname, string PersonalMessage) : ICommand<Guid>;

    internal sealed class UpdateBrideCommandHandler : ICommandHandler<UpdateBrideCommand, Guid>
    {
        private readonly IWeddingRepository _weddingRepository;

        public UpdateBrideCommandHandler(IWeddingRepository weddingRepository)
        {
            _weddingRepository = weddingRepository;
        }

        public async Task<Result<Guid>> Handle(UpdateBrideCommand request, CancellationToken cancellationToken)
        {
            var wedding = await _weddingRepository.GetMyWedding(cancellationToken);
            if(wedding is null)
            {
                return Result.Failure<Guid>(new Error("NotFound", "Could not find wedding"));
            }

            wedding.UpdateBride(request.Name, request.Surname, request.PersonalMessage);

            await _weddingRepository.Update(wedding);
            return wedding.Id;
        }
    }
}

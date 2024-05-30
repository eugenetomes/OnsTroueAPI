using EasyCompany.GenericResult.Core;
using OnsTrou.Application.Abstractions;
using OnsTrou.Application.Features.AccommodationFeature.Commands.CreateAccommodation;
using OnsTrou.Domain.Entities.WeddingGuestFeature;
using OnsTrou.Domain.Errors;
using OnsTrou.Domain.Repositories;
using OnsTrou.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.WeddingGuestFeature.Commands.CreateWeddingGuest;

public record CreateWeddingGuestCommand(string Name, string Surname, string PhoneNumber) : ICommand<string>;

internal sealed class CreateWeddingGuestCommandHandler : ICommandHandler<CreateWeddingGuestCommand, string>
{
    private readonly IWeddingGuestRepository _weddingGuestRepository;
    private readonly IWeddingRepository _weddingRepository;

    public CreateWeddingGuestCommandHandler(IWeddingGuestRepository weddingGuestRepository, IWeddingRepository weddingRepository)
    {
        _weddingGuestRepository = weddingGuestRepository;
        _weddingRepository = weddingRepository;
    }

    public async Task<Result<string>> Handle(CreateWeddingGuestCommand request, CancellationToken cancellationToken)
    {

        var wedding = await _weddingRepository.GetMyWedding(cancellationToken);
        if(wedding is null)
        {
            return Result.Failure<string>(DomainErrors.Weddings.NotFound);
        }


        var existingGuest = await _weddingGuestRepository.GetByIdAsync(request.PhoneNumber);

        var guestResult = WeddingGuest.Create(wedding.Id, request.Name, request.Surname, request.PhoneNumber, existingGuest is not null);
        if(guestResult.IsFailure)
        {
            return Result.Failure<string>(guestResult.Error);
        }

        await _weddingGuestRepository.Create(guestResult.Value);
        return guestResult.Value.Id;
    }
}
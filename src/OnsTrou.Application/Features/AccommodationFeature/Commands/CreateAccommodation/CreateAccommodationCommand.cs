using EasyCompany.GenericResult.Core;
using OnsTrou.Application.Abstractions;
using OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Errors;
using OnsTrou.Domain.Repositories;

namespace OnsTrou.Application.Features.AccommodationFeature.Commands.CreateAccommodation;


public record CreateAccommodationCommand(string Name, string Description, string ImagePath, string Website, int DistanceFromVenue, string Note) : ICommand<Guid>;

internal sealed class CreateAccommodationCommandHandler : ICommandHandler<CreateAccommodationCommand, Guid>
{
    private readonly IWeddingRepository _weddingRepository;
    private readonly IAccommodationRepository _accommodationRepository;

    public CreateAccommodationCommandHandler(IWeddingRepository weddingRepository, IAccommodationRepository accommodationRepository)
    {
        _weddingRepository = weddingRepository;
        _accommodationRepository = accommodationRepository;
    }

    public async Task<Result<Guid>> Handle(CreateAccommodationCommand request, CancellationToken cancellationToken)
    {
        var wedding = await _weddingRepository.GetMyWedding(cancellationToken);
        if (wedding is null)
        {
            return Result.Failure<Guid>(DomainErrors.Weddings.NotFound);
        }

        var accommodationResult = Accommodation.Create(wedding.Id, request.Name, request.Description, request.ImagePath, request.Website, request.DistanceFromVenue, request.Note);
        if (accommodationResult.IsFailure)
        {
            return Result.Failure<Guid>(accommodationResult.Error);
        }

        await _accommodationRepository.Create(accommodationResult.Value, cancellationToken);

        return Guid.Parse(accommodationResult.Value.Id);
    }
}
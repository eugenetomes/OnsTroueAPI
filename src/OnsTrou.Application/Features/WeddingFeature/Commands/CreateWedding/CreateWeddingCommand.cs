using EasyCompany.GenericResult.Core;
using OnsTrou.Application.Abstractions;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Repositories;

namespace OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;

public record CreateWeddingCommand(
            string Name,
            DateTime EventDateUtc,
            CreateWeddingCommand.BrideRecord Bride,
            CreateWeddingCommand.GroomRecord Groom,
            CreateWeddingCommand.WeddingVenue Venue) : ICommand<Guid>
{
    public record BrideRecord(string Name, string Surname, string PersonalMessage, string Email, string Telephone);
    public record GroomRecord(string Name, string Surname, string PersonalMessage, string Email, string Telephone);
    public record WeddingVenue(string Name, string Description, decimal Latitude, decimal Longitude);

};

internal sealed class CreateWeddingCommandHandler : ICommandHandler<CreateWeddingCommand, Guid>
{
    private readonly IWeddingRepository _weddingRepository;

    public CreateWeddingCommandHandler(IWeddingRepository weddingRepository)
    {
        _weddingRepository = weddingRepository;
    }

    public async Task<Result<Guid>> Handle(CreateWeddingCommand request, CancellationToken cancellationToken)
    {
        var groom = new Groom(request.Groom.Name, request.Groom.Surname, request.Groom.PersonalMessage, request.Groom.Email, request.Groom.Telephone);
        var bride = new Bride(request.Bride.Name, request.Bride.Surname, request.Bride.PersonalMessage, request.Bride.Email, request.Bride.Telephone);
        var venue = new WeddingVenue(request.Venue.Name, request.Venue.Description, request.Venue.Latitude, request.Venue.Longitude);

        var weddingResult = Wedding.Create(request.Name, request.EventDateUtc, bride, groom, venue);
        if (weddingResult.IsFailure)
        {
            return Result.Failure<Guid>(weddingResult.Error);
        }


        await _weddingRepository.Create(weddingResult.Value, cancellationToken);
        return weddingResult.Value.Id;
    }
}
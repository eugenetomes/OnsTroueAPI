using OnsTrou.App.Contracts.WeddingFeature;
using OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;

namespace OnsTrou.App.Mappers.WeddingFeature;

internal static class CreateWeddingRequestMapper
{
    public static CreateWeddingCommand MapToCreateWeddingCommand(this CreateWeddingRequest request)
    {
        var bride = new CreateWeddingCommand.BrideRecord(request.Bride.Name, request.Bride.Surname, request.Bride.PersonalMessage);
        var groom = new CreateWeddingCommand.GroomRecord(request.Groom.Name, request.Groom.Surname, request.Groom.PersonalMessage);
        var venue = new CreateWeddingCommand.WeddingVenue(request.Venue.Name, request.Venue.Description, request.Venue.Latitude, request.Venue.Longitude);

        var command = new CreateWeddingCommand(
            request.Name,
            request.EventDateUtc,
            bride,
            groom,
            venue
            );
        return command;
    }
}

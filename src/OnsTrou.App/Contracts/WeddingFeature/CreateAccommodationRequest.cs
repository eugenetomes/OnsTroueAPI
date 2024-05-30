using OnsTrou.Application.Features.AccommodationFeature.Commands.CreateAccommodation;

namespace OnsTrou.App.Contracts.WeddingFeature;


public record CreateAccommodationRequest(string Name, string Description, string ImagePath, string Website, int DistanceFromVenue, string Note);

public static class CreateAccommodationRequestMapper
{
    public static CreateAccommodationCommand MapToCreateAccommodationCommand(this CreateAccommodationRequest request)
    {
        var command = new CreateAccommodationCommand(request.Name,
            request.Description,
            request.ImagePath,
            request.Website,
            request.DistanceFromVenue,
            request.Note);

        return command;
    }

}

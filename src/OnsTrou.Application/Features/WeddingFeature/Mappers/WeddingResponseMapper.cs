using OnsTrou.Application.Features.WeddingFeature.Queries;
using OnsTrou.Domain.Entities.WeddingFeature;

namespace OnsTrou.Application.Features.WeddingFeature.Mappers;

internal static class WeddingResponseMapper
{
    public static WeddingResponse MapToWeddingResponse(this Wedding wedding)
    {
        var bride = new WeddingResponse.BrideResponse(wedding.Bride.Name, wedding.Bride.Surname, wedding.Bride.PersonalMessage, wedding.Bride.Email ?? string.Empty, wedding.Bride.Telephone ?? string.Empty);
        var groom = new WeddingResponse.GroomResponse(wedding.Groom.Name, wedding.Groom.Surname, wedding.Groom.PersonalMessage, wedding.Groom.Email ?? string.Empty, wedding.Groom.Telephone ?? string.Empty);
        var venue = new WeddingResponse.WeddingVenue(wedding.Venue.Name, wedding.Venue.Description, wedding.Venue.Latitude, wedding.Venue.Longitude);

        var weddingResponse = new WeddingResponse(wedding.Name, wedding.EventDateUtc, bride, groom, venue);
        return weddingResponse;
    }
}

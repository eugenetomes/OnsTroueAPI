namespace OnsTrou.Application.Features.WeddingFeature.Queries;

public record WeddingResponse(string Name, DateTime EventDateUtc, WeddingResponse.BrideResponse Bride, WeddingResponse.GroomResponse Groom, WeddingResponse.WeddingVenue Venue)
{
    public record BrideResponse(string Name, string Surname, string PersonalMessage);
    public record GroomResponse(string Name, string Surname, string PersonalMessage);
    public record WeddingVenue(string Name, string Description, decimal Latitude, decimal Longitude);
}

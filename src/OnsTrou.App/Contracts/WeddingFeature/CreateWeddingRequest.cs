namespace OnsTrou.App.Contracts.WeddingFeature;

public class CreateWeddingRequest
{
    public string Name { get; set; }
    public DateTime EventDateUtc { get; set; }
    public BrideRecord Bride { get; set; }
    public GroomRecord Groom { get; set; }
    public WeddingVenue Venue { get; set; }


    public record BrideRecord(string Name, string Surname, string PersonalMessage);
    public record GroomRecord(string Name, string Surname, string PersonalMessage);
    public record WeddingVenue(string Name, string Description, decimal Latitude, decimal Longitude);

}
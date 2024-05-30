using OnsTrou.Application.Features.WeddingGuestFeature.Commands.CreateWeddingGuest;

namespace OnsTrou.App.Contracts.WeddingGuestFeature;

public record CreateWeddingGuestRequest(string Name, string Surname, string PhoneNumber);

internal static class CreateWeddingGuestRequestMapper
{
    public static CreateWeddingGuestCommand MapToCreateWeddingGuestCommand(this CreateWeddingGuestRequest request)
    {
        var command = new CreateWeddingGuestCommand(request.Name, request.Surname, request.PhoneNumber);
        return command;
    }

}


    

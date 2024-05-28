using EasyCompany.GenericResult.Core;
using OnsTrou.Application.Abstractions;
using OnsTrou.Domain.Entities.WeddingFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;

public record CreateWeddingCommand(
            string Name,
            DateTime EventDateUtc,
            CreateWeddingCommand.BrideRecord Bride,
            CreateWeddingCommand.GroomRecord Groom,
            CreateWeddingCommand.WeddingVenue Venue) : ICommand<Guid>
{
    public record BrideRecord(string Name, string Surname, string PersonalMessage);
    public record GroomRecord(string Name, string Surname, string PersonalMessage);
    public record WeddingVenue(string Name, string Description, decimal Latitude, decimal Longitude);

};

internal sealed class CreateWeddingCommandHandler : ICommandHandler<CreateWeddingCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateWeddingCommand request, CancellationToken cancellationToken)
    {
        var groom = new Groom(request.Groom.Name, request.Groom.Surname, request.Groom.PersonalMessage);
        var bride = new Bride(request.Bride.Name, request.Bride.Surname, request.Bride.PersonalMessage);
        var venue = new WeddingVenue(request.Venue.Name, request.Venue.Description, request.Venue.Latitude, request.Venue.Longitude);

        var weddingResult = Wedding.Create(request.Name, request.EventDateUtc, bride, groom, venue);
        if (weddingResult.IsFailure)
        {
            return Result.Failure<Guid>(weddingResult.Error);
        }


        await Task.Delay(1);
        return Guid.NewGuid();
    }
}
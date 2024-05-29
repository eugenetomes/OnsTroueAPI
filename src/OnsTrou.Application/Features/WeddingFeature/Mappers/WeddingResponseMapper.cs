using OnsTrou.Application.Features.WeddingFeature.Queries;
using OnsTrou.Domain.Entities.WeddingFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.WeddingFeature.Mappers
{
    internal static class WeddingResponseMapper
    {
        public static WeddingResponse MapToWeddingResponse(this Wedding wedding)
        {
            var bride = new WeddingResponse.BrideResponse(wedding.Bride.Name, wedding.Bride.Surname, wedding.Bride.PersonalMessage);
            var groom = new WeddingResponse.GroomResponse(wedding.Groom.Name, wedding.Groom.Surname, wedding.Groom.PersonalMessage);
            var venue = new WeddingResponse.WeddingVenue(wedding.Venue.Name, wedding.Venue.Description, wedding.Venue.Latitude, wedding.Venue.Longitude);

            var weddingResponse = new WeddingResponse(wedding.Name, wedding.EventDateUtc, bride, groom, venue);
            return weddingResponse;
        }
    }
}

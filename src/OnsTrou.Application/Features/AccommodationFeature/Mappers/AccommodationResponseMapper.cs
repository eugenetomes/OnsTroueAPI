using OnsTrou.Application.Features.AccommodationFeature.Queries;
using OnsTrou.Domain.Entities.WeddingFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.AccommodationFeature.Mappers
{
    internal static class AccommodationResponseMapper
    {
        public static AccommodationResponse MapToAccommodationResponse(this Accommodation accommodation)
        {
            var accommodationResponse = new AccommodationResponse(Guid.Parse(accommodation.Id),
                accommodation.Name,
                accommodation.Description,
                accommodation.ImagePath,
                accommodation.Website,
                accommodation.DistanceFromVenue,
                accommodation.Note);
            return accommodationResponse;
        }
    }
}

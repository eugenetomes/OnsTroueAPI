using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.AccommodationFeature.Queries
{
    public record AccommodationResponse(Guid Id, string Name, string Description, string ImagePath, string Website, int DistanceFromVenue, string Note);
}

using OnsTrou.Application.Abstractions;
using OnsTrou.Application.Features.WeddingFeature.Queries.GetMyWedding;
using OnsTrou.Application.Features.WeddingFeature.Queries;
using EasyCompany.GenericResult.Core;
using OnsTrou.Domain.Repositories;
using OnsTrou.Application.Features.AccommodationFeature.Mappers;

namespace OnsTrou.Application.Features.AccommodationFeature.Queries.GetAllAccommodation
{
    public record GetAllAccommodationQuery() : IQuery<List<AccommodationResponse>>;

    internal sealed class GetAllAccommodationQueryHandler : IQueryHandler<GetAllAccommodationQuery, List<AccommodationResponse>>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        public GetAllAccommodationQueryHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Result<List<AccommodationResponse>>> Handle(GetAllAccommodationQuery request, CancellationToken cancellationToken)
        {
            var accommodationList = await _accommodationRepository.GetAll(cancellationToken);

            if(accommodationList is null)
            {
                return new List<AccommodationResponse>();
            }

            return accommodationList.Select(x => x.MapToAccommodationResponse()).OrderBy(x => x.DistanceFromVenue).ToList();
        }
    }
}

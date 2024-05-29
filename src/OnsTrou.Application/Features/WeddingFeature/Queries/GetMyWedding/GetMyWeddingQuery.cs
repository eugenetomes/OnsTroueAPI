using EasyCompany.GenericResult.Core;
using OnsTrou.Application.Abstractions;
using OnsTrou.Application.Features.WeddingFeature.Mappers;
using OnsTrou.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Application.Features.WeddingFeature.Queries.GetMyWedding;

public record GetMyWeddingQuery() : IQuery<WeddingResponse>;

internal sealed class GetMyWeddingQueryHandler : IQueryHandler<GetMyWeddingQuery, WeddingResponse>
{
    private readonly IWeddingRepository _weddingRepository;

    public GetMyWeddingQueryHandler(IWeddingRepository weddingRepository)
    {
        _weddingRepository = weddingRepository;
    }

    public async Task<Result<WeddingResponse>> Handle(GetMyWeddingQuery request, CancellationToken cancellationToken)
    {
        var wedding = await _weddingRepository.GetMyWedding(cancellationToken);
        if(wedding is null)
        {
            return Result.Failure<WeddingResponse>(new Error("NotFound", "Could not find your wedding"));
        }

        var weddingResponse = wedding.MapToWeddingResponse();
        return weddingResponse;
    }
}

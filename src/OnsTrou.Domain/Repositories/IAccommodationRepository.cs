using OnsTrou.Domain.Entities.WeddingFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Repositories;

public interface IAccommodationRepository
{
    Task<List<Accommodation>> GetAll(CancellationToken cancellationToken = default);
    Task Create(Accommodation accommodation, CancellationToken cancellationToken = default);
}

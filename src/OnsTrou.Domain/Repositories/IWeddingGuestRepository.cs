using OnsTrou.Domain.Entities.WeddingGuestFeature;
using OnsTrou.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Repositories;

public interface IWeddingGuestRepository
{
    Task Create(WeddingGuest weddingGuest, CancellationToken cancellationToken = default);
    Task<List<WeddingGuest>> GetAll(CancellationToken cancellationToken = default);
    Task<WeddingGuest> GetByIdAsync(string phoneNumber, CancellationToken cancellationToken = default);
}

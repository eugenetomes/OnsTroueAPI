using OnsTrou.Domain.Entities.WeddingFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Repositories
{
    public interface IWeddingRepository
    {
        Task Create(Wedding wedding, CancellationToken cancellationToken = default);
    }
}

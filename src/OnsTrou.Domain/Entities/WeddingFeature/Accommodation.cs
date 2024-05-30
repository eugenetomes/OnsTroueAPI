using EasyCompany.GenericResult.Core;
using OnsTrou.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities.WeddingFeature
{
    public class Accommodation : WeddingEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Website { get; private set; }
        public int DistanceFromVenue { get; private set; }
        public string Note { get; private set; }

        public Accommodation()
        {
            
        }

        public Accommodation(Guid weddingId, string name, string description, string imagePath, string website, int distanceFromVenue, string note) : base(nameof(Accommodation), weddingId, Guid.NewGuid())
        {
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Website = website;
            DistanceFromVenue = distanceFromVenue;
            Note = note;
        }

        public static Result<Accommodation> Create(Guid weddingId, string name, string description, string imagePath, string website, int distanceFromVenue, string note)
        {
            var accommodation = new Accommodation(weddingId, name, description, imagePath, website, distanceFromVenue, note);

            return accommodation;
        }
    }
}

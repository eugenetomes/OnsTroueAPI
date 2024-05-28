using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities.WeddingFeature;

public class WeddingVenue
{
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Latitude { get; init; }
    public decimal Longitude { get; init; }

    public WeddingVenue()
    {

    }

    public WeddingVenue(string name, string description, decimal latitude, decimal longitude)
    {
        Name = name;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
    }
}

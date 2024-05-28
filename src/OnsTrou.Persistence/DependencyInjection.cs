using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnsTrou.Domain.Repositories;
using OnsTrou.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        //var awsOptions = configuration.GetAWSOptions();
        //services.AddDefaultAWSOptions(awsOptions);
        //services.AddAWSService<IAmazonDynamoDB>();
        //services.AddScoped<IDynamoDBContext, DynamoDBContext>();

        //Repositories
        services.AddScoped<IWeddingRepository, WeddingRepository>();

        return services;
    }
}
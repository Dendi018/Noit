using Appliction.Core;
using Appliction.Events;
using MediatR;

namespace API.Extentoins
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}

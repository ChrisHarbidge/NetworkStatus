using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetworkStatus.Persistence.Data;
using NetworkStatus.Persistence.Repositories;
using NetworkStatus.WebApi.Mappers;
using NetworkStatus.WebApi.Services;

namespace NetworkStatus.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Filename=database.db"), ServiceLifetime.Transient);

            services.AddTransient<INodeStatusRepository, NodeStatusRepository>();
            services.AddTransient<IHardwareStatusRepository, HardwareStatusRepository>();
            services.AddTransient<ILinuxServiceStatusRepository, LinuxServiceStatusRepository>();
            services.AddTransient<INetworkStatusRepository, NetworkStatusRepository>();
            services.AddTransient<IStorageStatusRepository, StorageStatusRepository>();
            services.AddTransient<INodeStatusService, NodeStatusService>();
            services.AddTransient<IMapper, Mapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}

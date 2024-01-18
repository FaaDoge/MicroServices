using RestauranteTuliette.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestauranteTuliette.Services.InterfacesService;
using RestauranteTuliette.Services.ImplementationServices;

namespace RestauranteTuliette
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APITiendaEG", Version = "v1" });
            });
            services.AddDbContext<RestauranteTulietteContext>(options => options.UseSqlServer(
                     Configuration.GetConnectionString("cadenaConexion")));
            services.AddTransient<IBebidumService, BebidumService>();
            services.AddTransient<IIngredienteService, IngredienteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APITiendaEG v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
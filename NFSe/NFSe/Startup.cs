using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NFSe.Context;
using NFSe.Services;

namespace NFSe
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddControllers();

            services.AddEntityFrameworkSqlServer()
            .AddDbContext<BaseContext>(options =>
            {
                options.UseSqlServer("Data Source=localhost;Initial Catalog=AppNFSeOficial;User ID=rm;Password=rm;",
                    b =>
                    {
                        b.MigrationsAssembly("NFSe");
                   });
            });

          // Instancia o objeto
          services.AddScoped<IEmpresaService, EmpresaService>(); 
          services.AddScoped<IFilialService, FilialService>();
          services.AddScoped<IClienteService, ClienteService>();
          services.AddScoped<IEstadoService, EstadoService>();
          services.AddScoped<IMunicipioService, MunicipioService>();
          services.AddScoped<IPaisService, PaisService>();
          services.AddScoped<ISerieService, SerieService>();
          services.AddScoped<IServicoService, ServicoService>();
          services.AddScoped<ITipoBairroService, TipoBairroService>();
          services.AddScoped<ITipoLogradouroService, TipoLogradouroService>();
          services.AddScoped<ITributoService, TributoService>();
          services.AddScoped<IUnidadeService, UnidadeService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
                RequestPath = new PathString("/StaticFiles")
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

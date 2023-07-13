using Escola.API.DataBase;
using Escola.API.DataBase.Repositories;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API
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
            services.AddDbContext<EscolaDbContexto>();
            services.AddControllers();

            services.AddScoped<IAlunoService,AlunoService>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<IBoletimService, BoletimService>();
            services.AddScoped<IBoletimRepository, BoletimRepository>();

            services.AddMemoryCache();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Escola.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Escola.API v1"));
            }

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Services;
using ClinicaVeterinaria.Services.List;
using ClinicaVeterinaria.Models.ViewModels;

namespace ClinicaVeterinaria
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
            services.Configure<CookiePolicyOptions>(configureOptions: options => 
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ClinicaVeterinariaContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("ClinicaVeterinariaContext"), builder =>
            builder.MigrationsAssembly("ClinicaVeterinaria")));

            services.AddScoped<SeedingService>();            
            services.AddScoped<ClienteService>();
            services.AddScoped<AnimalService>();
            services.AddScoped<EspecieService>();
            services.AddScoped<ListEspecieService>();
            services.AddScoped<ListProprietarioService>();
            services.AddScoped<ListAnimalService>();
            services.AddScoped<VeterinarioService>();
            services.AddScoped<ConsultaService>();
            services.AddScoped<ListVeterinarioService>();
            services.AddScoped<ProprietarioService>();
            services.AddScoped<ExameService>();
            services.AddScoped<MedicamentoService>();
            services.AddScoped<ListMedicamentoService>();
            services.AddScoped<ListConsultaService>();
            services.AddScoped<CaixaService>();
            services.AddScoped<ListExameService>();
            

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
        {

            var enUS = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };

            app.UseRequestLocalization(localizationOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

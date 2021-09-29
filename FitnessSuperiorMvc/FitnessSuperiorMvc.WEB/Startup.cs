using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Interfaces;
using FitnessSuperiorMvc.DA.Repositories;
using FitnessSuperiorMvc.Services.People;
using FitnessSuperiorMvc.Services.Programs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FitnessSuperiorMvc.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<FitnessAppContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<SecurityContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SecurityContext>();

            services.AddScoped<ExerciseService>();
            services.AddScoped<SetOfExercisesService>();
            services.AddScoped<TrainingProgramsService>();

            services.AddScoped<FoodService>();
            services.AddScoped<MealPlanService>();
            services.AddScoped<NutritionProgramService>();

            services.AddScoped<UserService>();
            services.AddScoped<TrainerService>();
            services.AddScoped<NutritionistService>();
            services.AddScoped<ManagerService>();

            services.AddScoped<CalendarService>();

            services.AddScoped<ISecretesStorage, SecretesStorage>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IFitnessServicesRepository, FitnessServicesRepository>();

            services.Add(ServiceDescriptor.Scoped(typeof(IRepository<>), typeof(FitnessAppRepository<>)));

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(p =>
            {
                p.LoginPath = "/Account/Login";
                p.Cookie.Name = "Fitness";
                p.AccessDeniedPath = "/Account/AccessDenied";
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

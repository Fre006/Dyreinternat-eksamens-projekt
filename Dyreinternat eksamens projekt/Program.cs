using System.Runtime.InteropServices;
using Lib.Repo;
using Lib.Services;

namespace Dyreinternat_eksamens_projekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Singleton for Activity.Repo
            builder.Services.AddSingleton<IActivityJSONRepo, ActivityJSONRepo>();
            builder.Services.AddSingleton<ActivityService>();

            //Singleton for Event repository
            builder.Services.AddSingleton<IEventJSONRepo, EventJSONRepo>();
            builder.Services.AddSingleton<EventService>();

            //Singleton for Animal repository
            builder.Services.AddSingleton<IAnimalRepo, AnimalRepo>();
            builder.Services.AddSingleton<AnimalService>();

            //Singleton for Blog repository
            builder.Services.AddSingleton<IBlogJSONRepo, BlogJSONRepo>();
            builder.Services.AddSingleton<BlogService>();

            //Singleton for Booking repository
            builder.Services.AddSingleton<IBookingJSONRepo, BookingJSONRepo>();
            builder.Services.AddSingleton<BookingService>();

            //Singleton for Cat repository
            builder.Services.AddSingleton<ICatJSONRepo, CatJSONRepo>();
            builder.Services.AddSingleton<CatService>();

            //Singleton for Costumer repository
            builder.Services.AddSingleton<ICostumerJSONRepo, CostumerJSONRepo>();
            builder.Services.AddSingleton<CostumerService>();

            //Singleton for Dog repository
            builder.Services.AddSingleton<IDogJSONRepo, DogJSONRepo>();
            builder.Services.AddSingleton<DogService>();

            //Singleton for Veterinarian repository
            builder.Services.AddSingleton<IVeterinarianJSONRepo, VeterinarianJSONRepo>();
            builder.Services.AddSingleton<VeterinarianService>();

            //Singleton for Worker repository
            builder.Services.AddSingleton<IWorkerJSONRepo, WorkerJSONRepo>();
            builder.Services.AddSingleton<WorkerService>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}

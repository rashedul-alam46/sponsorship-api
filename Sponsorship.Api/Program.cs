using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.Mappings;
using Sponsorship.Application.Services;
using Sponsorship.Application.Factories;
using Sponsorship.Infrastructure.Data;
using Sponsorship.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();



builder.Services.AddDbContext<SponsorshipDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("ConString")));

// Register repositories and services
builder.Services.AddScoped<IServiceResponseFactory, ServiceResponseFactory>();

builder.Services.AddScoped<ISponsorshipRequestRepository, SponsorshipRequestRepository>();
builder.Services.AddScoped<ISponsorshipRequestService, SponsorshipRequestService>();

builder.Services.AddScoped<IDropdownRepository, DropdownRepository>();
builder.Services.AddScoped<IDropdownService, DropdownService>();

// AutoMapper
builder.Services.AddAutoMapper(_ => { }, typeof(MasterProfile).Assembly);


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// CORS (for Blazor or frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();


// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Redirect root to Swagger
    app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
}


// CORS
app.UseCors("AllowBlazor");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<SponsorshipDbContext>();

//     // Apply migrations first (important)
//     await context.Database.MigrateAsync();

//     // Run seeder
//     await DatabaseSeeder.SeedAsync(context);
// }

app.Run();


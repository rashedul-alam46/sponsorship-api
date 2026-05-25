using Sponsorship.Application.Interfaces.Repositories;
using Sponsorship.Application.Interfaces.Services;
using Sponsorship.Application.Mappings;
using Sponsorship.Application.Services;
using Sponsorship.Application.Factories;
using Sponsorship.Infrastructure.Data;
using Sponsorship.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Sponsorship.Interfaces.Helpers;
using Sponsorship.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Controllers
// =====================
builder.Services.AddControllers();

// =====================
// DB Context
// =====================
builder.Services.AddDbContext<SponsorshipDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConString")));

// =====================
// Dependency Injection
// =====================
builder.Services.AddScoped<IServiceResponseFactory, ServiceResponseFactory>();

builder.Services.AddScoped<ISponsorshipRequestRepository, SponsorshipRequestRepository>();
builder.Services.AddScoped<ISponsorshipRequestService, SponsorshipRequestService>();

builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IAppUserService, AppUserService>();

builder.Services.AddScoped<ISponsorshipTypeRepository, SponsorshipTypeRepository>();
builder.Services.AddScoped<ISponsorshipTypeService, SponsorshipTypeService>();

builder.Services.AddScoped<IDropdownRepository, DropdownRepository>();
builder.Services.AddScoped<IDropdownService, DropdownService>();

builder.Services.AddScoped<IWorkflowHistoryRepository, WorkflowHistoryRepository>();
builder.Services.AddScoped<IWorkflowHistoryService, WorkflowHistoryService>();

builder.Services.AddScoped<IUnitOfWork, MasterUnitOfWork>();

builder.Services.AddScoped<IAccountAuthService, AccountAuthService>();

// =====================
// AutoMapper
// =====================
builder.Services.AddAutoMapper(_ => { }, typeof(MasterProfile).Assembly);

// =====================
// Swagger
// =====================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====================
// CORS (IMPORTANT FIXED)
// =====================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorFrontend", policy =>
    {
        policy.WithOrigins("https://sponsorship-web.onrender.com")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// =====================
// Middleware Pipeline
// =====================
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

// Apply CORS policy before authorization
app.UseCors("AllowBlazorFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
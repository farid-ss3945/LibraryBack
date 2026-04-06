using FluentValidation;
using FluentValidation.AspNetCore;
using Library.API.AuthCommands;
using Library.API.Controllers;
using Library.API.Extensions;
using Library.Application.BookCommands;
using Library.Application.Interfaces;
using Library.Application.Mapping;
using Library.Application.Queries.Books;
using Library.Domain;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using SixLabors.ImageSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerMethod();
builder.Services.AddScoped<IBookRepo, BookRepository>();
builder.Services.AddScoped<IUserRepo, UserRepository>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(AddBookCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetBooksQuery).Assembly);
});
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<OnlineLibDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
    options.AddPolicy("LibrarianOrAbove", policy =>
        policy.RequireRole("Admin","Librarian"));
});
builder.Services.AddCorsPolicy();

builder.Services.AddLibraryDbContext(builder.Configuration);



builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

var app = builder.Build();
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
await app.EnsureRolesSeededAsync();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
using AssessmentPaper.WebApi;
using AssessmentPaper.WebApi.Areas.Data;
using AssessmentPaper.WebApi.Areas.Policies;
using AssessmentPaper.WebApi.Areas.Policies.Admin;
using AssessmentPaper.WebApi.Areas.Policies.Read;
using AssessmentPaper.WebApi.Areas.Policies.Write;
using AssessmentPaper.WebApi.DISettings;
using AssessmentPaper.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adds Custom filters
builder.Services.AddMvc(options => options.Filters.Add(new HandleExceptionAttribute()));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddClients();

builder.Services.Configure<ServicesSettings>(
    builder.Configuration.GetSection(nameof(ServicesSettings)));

// Adds sql server for identity
builder.Services.AddDbContext<IdentityDatabaseContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbConnectionString")));
 
// adds Identity to WebApi
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => 
    options.Password.RequiredLength = 8)
    .AddEntityFrameworkStores<IdentityDatabaseContext>()
    .AddDefaultTokenProviders();

// Authorization Policies
builder.Services.AddAuthorization(options =>{
    options.AddPolicy(
        "CanWrite",
        policyBuilder => 
        policyBuilder.AddRequirements(
            new WriteRequirement()
        )
    );
    options.AddPolicy(
        "CanRead",
        policyBuilder =>
        policyBuilder.AddRequirements(
            new ReadRequirement()
        )
    );
    options.AddPolicy(
        "CanControl",
        policyBuilder =>
        policyBuilder.AddRequirements(
            new AdminRequirement()
        )
    );
});

// Authorization Handlers
builder.Services.AddSingleton<IAuthorizationHandler, AdminHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, WriteHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, ReadHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, AdminToWriteHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, AdminToReadHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, WriteToReadHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

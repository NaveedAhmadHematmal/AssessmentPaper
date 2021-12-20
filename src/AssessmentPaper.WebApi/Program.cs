using AssessmentPaper.WebApi;
using AssessmentPaper.WebApi.Areas.Data;
using AssessmentPaper.WebApi.DISettings;
using AssessmentPaper.WebApi.Filters;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Adds Custom filters
builder.Services.AddMvc(options => options.Filters.Add(new HandleExceptionAttribute()));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adds serilog logger
builder.Host.UseSerilog((ctx, lc) => 
{
    ctx.Configuration.GetSection("Logging");
    lc.WriteTo.File("Logs/Log.txt");
    lc.WriteTo.Console();
    lc.WriteTo.Seq(ctx.Configuration.GetValue<string>("SeqHostAddress"));
});

builder.Services.AddClients();

builder.Services.Configure<ServicesSettings>(
    builder.Configuration.GetSection(nameof(ServicesSettings)));

// Adds sql server for identity
builder.Services.AddDbContext<IdentityDatabaseContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbConnectionString")));

builder.Services.AddIdentity();

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

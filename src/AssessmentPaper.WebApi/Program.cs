using AssessmentPaper.WebApi;
using AssessmentPaper.WebApi.DISettings;
using AssessmentPaper.WebApi.Filters;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

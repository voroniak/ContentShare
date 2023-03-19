using Microsoft.OpenApi.Models;
using Notes.API.Data;
using Notes.API.Data.Interfaces;
using Notes.API.Repositories;
using Notes.API.Repositories.Interfaces;
using Notes.API.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<NotesDatabaseSettings>(
    builder.Configuration.GetSection("NotesDatabaseSettings"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});



builder.Services.AddSingleton<INotesContext, NotesContext>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();

builder.Services.AddOptions();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notes.API", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes.API v1"));


app.UseAuthorization();

app.MapControllers();

app.Run();

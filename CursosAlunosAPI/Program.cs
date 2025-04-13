using CursosAlunosAPI.Repositories;
using CursosAlunosAPI.Repositories.Interfaces;
using CursosAlunosAPI.Services;
using CursosAlunosAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar repositórios
builder.Services.AddSingleton<ICursoRepository, CursoRepository>();
builder.Services.AddSingleton<IAlunoRepository, AlunoRepository>();

// Registrar serviços
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();

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
using BackEnd;
using BackEnd.BusinessLogic.Interfaces;
using BackEnd.BusinessLogic.Servicios;
using BackEnd.ModeloDb;
using BackEnd.Utilidad;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PruebaTecnicaContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));
builder.Services.AddScoped<IEntidadBL, EntidadService>();
builder.Services.AddScoped<IEmpleadoBL, EmpleadoService>();
builder.Services.AddScoped<IUsuarioBL, UsuarioService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(op => op.AddPolicy("AplicacionWebCliente", op => op.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

var appSetingsSections = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSetingsSections);

var appSettings = appSetingsSections.Get<AppSettings>();
var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);

builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(d =>
    {
        d.RequireHttpsMetadata = false;
        d.SaveToken = true;
        d.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(llave),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });





var app = builder.Build();
app.UseCors("AplicacionWebCliente");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

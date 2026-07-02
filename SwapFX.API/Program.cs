using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Interfaces;
using SwapFX.CORE.Core.Services;
using SwapFX.CORE.Infrastructure.Data;
using SwapFX.CORE.Infrastructure.Repositories;
using SwapFX.CORE.Infrastructure.Shared;
var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var cnx = config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<SwapFXDbContext>(options => options.UseSqlServer(cnx));
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IOfertaRepository, OfertaRepository>();
builder.Services.AddTransient<IOfertaService, OfertaService>();
builder.Services.AddSharedInfrastructure(config);
builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", b => {
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "SwapFX API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
        Name = "Authorization", Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer", BearerFormat = "JWT", In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingresa: Bearer {token}"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        { new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
            Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "Bearer"
            }
        }, Array.Empty<string>() }
    });
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

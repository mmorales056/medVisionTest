using AccesoDatos;
using ApiMedVision.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;
using UnidadDeTrabajo;
 

var builder = WebApplication.CreateBuilder(args);

//cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


// Add services to the container.

builder.Services.AddSingleton<IUnidadDeTrabajo>(option => new UnidadDeTrabajoClase(
    builder.Configuration.GetConnectionString("dbMedVision")
    )
);

var token = new JwtProvider("issuer", "audience", "medVision");
builder.Services.AddSingleton<ITokenProvider>(token);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = token.GetValidationParameters();

    });



builder.Services.AddAuthorization(auth =>
{
    auth.DefaultPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseAuthentication();

app.Run();

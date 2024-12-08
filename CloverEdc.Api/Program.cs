using System.Security.Claims;
using System.Text;
using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Business.Services;
using CloverEdc.Core.Interfaces;
using CloverEdc.Data;
using CloverEdc.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CloverEdc.Data.Context;

var builder = WebApplication.CreateBuilder(args);


#region connection string

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region authentication and authorization

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
            RoleClaimType = ClaimTypes.Role
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

#endregion

#region Interface and Service registration

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPiSiteRepository, PiSiteRepository>();
builder.Services.AddScoped<AuthHelper>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICrcRepository, CrcRepository>();
builder.Services.AddScoped<ICrcService, CrcService>();
builder.Services.AddScoped<IDmRepository, DmRepository>();
builder.Services.AddScoped<IDmService, DmService>();
builder.Services.AddScoped<IPiRepository, PiRepository>();
builder.Services.AddScoped<IPiService, PiService>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IStudyRepository, StudyRepository>();
builder.Services.AddScoped<IStudyService, StudyService>();
builder.Services.AddScoped<IProtocolRepository, ProtocolRepository>();
builder.Services.AddScoped<IProtocolService, ProtocolService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ICrfRepository, CrfRepository>();
builder.Services.AddScoped<ICrfService, CrfService>();
builder.Services.AddScoped<ICrfTemplateRepository, CrfTemplateRepository>();
builder.Services.AddScoped<ICrfTemplateService, CrfTemplateService>();
builder.Services.AddScoped<ICrfFileRepository, CrfFileRepository>();
builder.Services.AddScoped<ICrfFileService, CrfFileService>();
builder.Services.AddScoped<ICrfPageRepository, CrfPageRepository>();
builder.Services.AddScoped<ICrfPageService, CrfPageService>();
builder.Services.AddScoped<ICrfFieldRepository, CrfFieldRepository>();
builder.Services.AddScoped<ICrfFieldService, CrfFieldService>();
builder.Services.AddScoped<ICrfValueRepository, CrfValueRepository>();
builder.Services.AddScoped<ICrfValueService, CrfValueService>();
builder.Services.AddScoped<IAuditTrailRepository, AuditTrailRepository>();
builder.Services.AddScoped<IAuditTrailService, AuditTrailService>();
builder.Services.AddScoped<IAdverseEventRepository, AdverseEventRepository>();
builder.Services.AddScoped<IAdverseEventService, AdverseEventService>();
builder.Services.AddScoped<IQueryRepository, QueryRepository>();
builder.Services.AddScoped<IQueryService, QueryService>();
builder.Services.AddScoped<ILockRepository, LockRepository>();
builder.Services.AddScoped<ILockService, LockService>();
builder.Services.AddScoped<ICrcSiteRepository, CrcSiteRepository>();
builder.Services.AddScoped<ICrcSiteService, CrcSiteService>();
builder.Services.AddScoped<IDmSiteRepository, DmSiteRepository>();
builder.Services.AddScoped<IDmSiteService, DmSiteService>();
builder.Services.AddScoped<IUpdateRequestRepository, UpdateRequestRepository>();
builder.Services.AddScoped<IUpdateRequestService, UpdateRequestService>();
#endregion

#region Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

#endregion

#region Add Services to Container

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

#region Swagger API

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

#endregion

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
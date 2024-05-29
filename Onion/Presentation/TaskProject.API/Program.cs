using TaskProject.Persistance;
using TaskProject.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskProject.Application.Tools;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskProject.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

#region Service Registration

builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);

#endregion

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
           .AddFluentValidation(configuration => configuration
               .RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>())
           .AddFluentValidation(configuration => configuration
               .RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
           .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);






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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

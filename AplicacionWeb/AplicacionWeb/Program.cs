
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models.Models;
using Service.IService;
using Service.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("AplicacionWeb", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "AplicacionWeb" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });
}); ;

#region Inyeccion de dependencia
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ISuperAdminService, SuperAdminService>();
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

#region Data Base
builder.Services.AddDbContext<TiendaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebConnection"))
);
#endregion

builder.Services.AddAuthentication("Bearer") 
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,   
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);


var app = builder.Build();

#region Migration
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<TiendaContext>();
//}

#endregion

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

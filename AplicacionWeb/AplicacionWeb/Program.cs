
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Service.IService;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);


#region Inyeccion de dependencia
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ISuperAdminService, SuperAdminService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Data Base
builder.Services.AddDbContext<TiendaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebConnection"))
);
#endregion

var app = builder.Build();

#region Migration
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<TiendaContext>();
//        context.Database.Migrate();
//}

#endregion

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

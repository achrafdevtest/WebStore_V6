using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Data.EF;
using WebStore.Middleware;
using WebStore.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("Store");
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseSwaggerDocumentation();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();
app.MigrateDatabase();
app.Run();

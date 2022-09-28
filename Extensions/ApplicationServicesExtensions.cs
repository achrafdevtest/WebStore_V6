using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.Core.Services;
using WebStore.DAL.Repository;
using WebStore.Errors;

namespace WebStore.Extensions;
public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       
        services.AddScoped<ITokenService, TokenSrevice>();
        services.AddScoped<IBrandsRepository, BrandsRepository>();
        services.AddTransient<BrandService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<CategoryService>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<StaffService>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<OrderService>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<AccountService>();

        services.Configure<ApiBehaviorOptions>(options =>

       options.InvalidModelStateResponseFactory = actionContext =>
       {
           var errors = actionContext.ModelState
               .Where(e => e.Value.Errors.Count > 0)
               .SelectMany(x => x.Value.Errors)
               .Select(c => c.ErrorMessage).ToArray();
           var errorResponse = new ApiValidationErrorResponse
           {
               Errors = errors
           };
           return new BadRequestObjectResult(errorResponse);

       });
        return services;
    }
}

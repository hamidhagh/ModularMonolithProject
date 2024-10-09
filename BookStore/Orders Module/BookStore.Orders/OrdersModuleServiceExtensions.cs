using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Serilog;
using BookStore.Orders.Infrastructure.Data;
using BookStore.Orders.Interfaces;
using BookStore.Orders.Infrastructure;

namespace BookStore.Orders;

public static class OrderModuleServiceExtensions
{
  public static IServiceCollection AddOrderModuleServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies)
  {
    string? connectionString = config.GetConnectionString("OrderProcessingConnectionString");
    services.AddDbContext<OrderProcessingDbContext>(config =>
      config.UseSqlServer(connectionString));

    // Add Services
    services.AddScoped<IOrderRepository, EfOrderRepository>();
    services.AddScoped<RedisOrderAddressCache>();
    services.AddScoped<IOrderAddressCache, ReadThroughOrderAddressCache>();

    // if using MediatR in this module, add any assemblies that contain handlers to the list
    mediatRAssemblies.Add(typeof(OrderModuleServiceExtensions).Assembly);

    logger.Information("{Module} module services registered", "OrderProcessing");

    return services;
  }
}

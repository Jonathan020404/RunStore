/*using System;
using Client.Factories;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<CustomersViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddTransient<OrdersViewModel>();
        collection.AddTransient<AddProductViewModel>();
        collection.AddTransient<IProductService, ProductServices>();
        collection.AddTransient<ICustomerService, CustomerServices>();

        collection.AddSingleton<Func<ApplicationNameEnum, PageViewModel>>(c =>
            name =>
                name switch
                {
                    ApplicationNameEnum.Home => c.GetRequiredService<HomeViewModel>(),
                    ApplicationNameEnum.Customers => c.GetRequiredService<CustomersViewModel>(),
                    ApplicationNameEnum.Products => c.GetRequiredService<ProductsViewModel>(),
                    ApplicationNameEnum.Orders => c.GetRequiredService<OrdersViewModel>(),
                    ApplicationNameEnum.AddProducts => c.GetRequiredService<AddProductViewModel>(),
                    _ => throw new InvalidOperationException("Det gick åt h-e"),
                }
        );
    }
}*/

using System;
using Client.Factories;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    // Syftet är att skapa en metod som lägger till tjänser services
    // i ServiceCollection objektet. Som vi fått via Microsoft.Extensions.DependencyInjection...
    public static void AddServices(this IServiceCollection collection)
    {
        // Om någon efterfrågar interface IProductService så ger
        // vi dem en instans av KalleAnka objektet...
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddTransient<CustomersViewModel>();
        collection.AddTransient<IProductService, ProductServices>();
    }
}

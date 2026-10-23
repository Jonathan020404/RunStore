using System;
using Client.Helpers;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;

namespace Client.Factories;

/*public class PageViewFactory(Func<ApplicationNameEnum, PageViewModel> pageFactory)
    : IPageViewFactory
{
    public PageViewModel LoadPageViewModel(ApplicationNameEnum pageName) =>
        pageFactory.Invoke(pageName);
}
*/

public class PageViewFactory : IPageViewFactory
{
    public ViewModelBase LoadPageViewModel(ApplicationNameEnum page)
    {
        return page switch
        {
            ApplicationNameEnum.Home => new HomeViewModel(),
            ApplicationNameEnum.Products => new ProductsViewModel(new ProductServices()),
            ApplicationNameEnum.Customers => new CustomersViewModel(new CustomerServices()),
            ApplicationNameEnum.AddProduct => new AddProductViewModel(),

            _ => throw new InvalidOperationException("Det fanns inte det du ville ha"),
        };
    }

    public ViewModelBase LoadPageViewModel(ApplicationNameEnum page, string itemNumber)
    {
        return page switch
        {
            ApplicationNameEnum.EditProduct => new EditProductViewModel(
                new ProductServices(),
                itemNumber
            ),
            _ => throw new InvalidOperationException("Det fanns inte det du ville ha"),
        };
    }
}

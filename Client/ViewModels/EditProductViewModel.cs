using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class EditProductViewModel : ViewModelBase
{
    private readonly IProductService _productService;
    private readonly string _itemNumber = string.Empty;

    [ObservableProperty]
    public partial string ProductName { get; set; } = "";

    /*public partial EditProductViewModel(string itemNumber)
    {
        _productService = new ProductServices();
        PageTitle = "Uppdatera Produkt " + itemNumber;
        _itemNumber = itemNumber;
        Init();
    }*/

    public EditProductViewModel(IProductService productService, string itemNumber)
    {
        _productService = productService;
        PageTitle = "Uppdatera Produkt " + itemNumber;
        _itemNumber = itemNumber;
        Init();
    }

    private async void Init()
    {
        await GetProduct();
    }

    private async Task GetProduct()
    {
        var product = await _productService.Find(_itemNumber);
        ProductName = product.Name;
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : PageViewModel
{
    private readonly IProductService _productService;

    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = [];

    public ProductsViewModel(IProductService service)
    {
        PageTitle = "Våra produkter";
        _productService = service;
        PageName = Helpers.ApplicationNameEnum.Products;

        //Task.Run(() => LoadProducts()).Wait();
        Init();
    }

    [RelayCommand]
    public void Delete(string id)
    {
        Console.WriteLine("Ta bort produkt " + id);
    }

    private async void Init()
    {
        await LoadProducts();
    }

    private async Task LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(await _productService.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

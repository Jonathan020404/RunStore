using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class CustomersViewModel : PageViewModel
{
    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers { get; set; } = [];

    private readonly ICustomerService _customerService;

    public CustomersViewModel(ICustomerService service)
    {
        PageTitle = "Våra kunder";
        _customerService = service;
        PageName = Helpers.ApplicationNameEnum.Customers;
        Init();
    }

    [RelayCommand]
    public void Edit(string id)
    {
        Console.WriteLine("Ändra uppgifter " + id);
    }

    [RelayCommand]
    public void Delete(string id)
    {
        Console.WriteLine("Ta bort produkt " + id);
    }

    private async void Init()
    {
        await LoadCustomers();
    }

    private async Task LoadCustomers()
    {
        try
        {
            Customers = new ObservableCollection<Customer>(await _customerService.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

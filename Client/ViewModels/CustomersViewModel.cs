using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    private readonly ICustomerService _service;

    public CustomersViewModel() { }

    public CustomersViewModel(ICustomerService service)
    {
        PageTitle = "Våra kunder";
        _service = service;
        PageName = Helpers.ApplicationNameEnum.Customers;
        LoadCustomers();
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

    private void LoadCustomers()
    {
        try
        {
            Customers = new ObservableCollection<Customer>(_service.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

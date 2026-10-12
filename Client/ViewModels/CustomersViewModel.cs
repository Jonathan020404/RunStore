using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers { get; set; } = [];

    private ICustomerService _service;

    public CustomersViewModel() { }

    public CustomersViewModel(ICustomerService service)
    {
        PageTitle = "Våra kunder";
        _service = service;
        LoadCustomers();
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

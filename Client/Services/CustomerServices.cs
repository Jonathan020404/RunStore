using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class CustomerServices
{
    static readonly string path = Directory.GetCurrentDirectory() + "/Data/customers.json";

    static readonly Storage<Customer> storage = new();

    public static List<Customer> ListAllCustomers()
    {
        var json = storage.Read(path);

        return json;
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class CustomerServices : ICustomerService
{
    public List<Customer> List()
    {
        var storage = new Storage<Customer>();
        var path = Directory.GetCurrentDirectory() + "/Data/customers.json";
        var json = storage.Read(path);

        return json;
    }
}

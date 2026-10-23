using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class CustomerServices : ICustomerService
{
    public async Task<List<Customer>> List()
    {
        var httpService = new HttpService<Customer>();
        var customers = await httpService.Get("customers");
        return customers;
    }
}

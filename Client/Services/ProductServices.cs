using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class ProductServices : IProductService
{
    public List<Product> List()
    {
        var storage = new Storage<Product>();
        var path = Directory.GetCurrentDirectory() + "/Data/products.json";
        var json = storage.Read(path);

        var sortedJson = json.OrderBy(x => x.ItemNumber).ToList();

        return sortedJson;
    }
}

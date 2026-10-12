using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class ProductServices
{
    static readonly string path = Directory.GetCurrentDirectory() + "/Data/products.json";

    static readonly Storage<Product> storage = new();

    public static List<Product> ListAllProducts()
    {
        var json = storage.Read(path);

        var sortedJson = json.OrderBy(x => x.ItemNumber).ToList();

        return sortedJson;
    }
}

using System;
using System.Collections.Generic;
using Client.Models;

namespace Client.Interfaces;

public interface IProductService
{
    public List<Product> List();
}

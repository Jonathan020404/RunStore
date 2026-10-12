using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Text.Json;
using Client.Interfaces;

namespace Client.Repositories;

public class Storage<T> : IStorage<T>
    where T : class
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
    };

    public List<T> Read(string path)
    {
        try
        {
            string data = File.ReadAllText(path);
            if (!string.IsNullOrWhiteSpace(data))
            {
                return JsonSerializer.Deserialize<List<T>>(data, _options) ?? [];
            }
            else
            {
                return [];
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Write(string path, List<T> data)
    {
        try
        {
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

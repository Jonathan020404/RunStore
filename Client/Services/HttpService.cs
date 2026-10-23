using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class HttpService<T> : IHttpService<T>
    where T : class
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true,
    };

    public async Task<List<T>> Get(string resource)
    {
        //steg 1. Skapa sökvägen till resursen
        var url = $"https://runstore-bf44.restdb.io/rest/{resource}";

        //steg 2. Skapa en instans av HttpClient(.NET) klassen
        using HttpClient client = new();

        //steg 3. Konfigurera HttpClient objektet.
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Cache-Control", "none");
        client.DefaultRequestHeaders.Add("x-apikey", "56c140264ea8793fd5504bc49563181b22b52");

        //steg 4. Skicka paketet
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return [];

        var result = await response.Content.ReadAsStreamAsync();

        var list = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
        return list;
    }

    public async Task<T> Get(string resource, string predicate)
    {
        try
        {
            var url = $"https://runstore-bf44.restdb.io/rest/{resource}?q={predicate}";

            using HttpClient client = new();

            //steg 3. Konfigurera HttpClient objektet.
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("Cache-Control", "none");
            client.DefaultRequestHeaders.Add("x-apikey", "56c140264ea8793fd5504bc49563181b22b52");

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(result))
                {
                    throw new Exception("Fanns ingenting");
                }

                var data = JsonSerializer.Deserialize<List<T>>(result, _options)!;
                return data[0];
            }

            throw new Exception("Det gick fel: " + response.StatusCode);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Post(string resource, T data)
    {
        try
        {
            var url = $"https://runstore-bf44.restdb.io/rest/{resource}";

            using HttpClient client = new();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("Cache-Control", "none");
            client.DefaultRequestHeaders.Add("x-apikey", "56c140264ea8793fd5504bc49563181b22b52");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            await client.PostAsJsonAsync<T>(url, data);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

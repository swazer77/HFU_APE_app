using MLZ2025.Core.Model;
using Newtonsoft.Json;

namespace MLZ2025.Core.Tests;

public class HttpServerAccess
{
    private readonly HttpClient _client;

    public HttpServerAccess(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("http://localhost:3000");
    }

    public async Task<IList<Address>> GetAddressesAsync()
    {
        var response = await _client.GetAsync("/addresses/");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<IList<Address>>(content);

        if (result == null)
        {
            throw new InvalidOperationException("Could not get addresses from server.");
        }

        return result;
    }
}

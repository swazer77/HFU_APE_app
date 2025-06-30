using System.Net;
using MLZ2025.Core.Model;
using Newtonsoft.Json;

namespace MLZ2025.Core.Tests;

[TestFixture]
public class HttpClientTests : TestsBase
{
    [Test]
    public async Task TestGetAddresses()
    {
        var serviceProvider = CreateServiceProvider();
        var httpClient = serviceProvider.GetRequiredService<HttpClient>();

        httpClient.BaseAddress = new Uri("http://localhost:3000");

        var result = await httpClient.GetAsync("/addresses/");

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(result.IsSuccessStatusCode, Is.True);

        var stringResult = await result.Content.ReadAsStringAsync();

        var addresses = JsonConvert.DeserializeObject<IList<Address>>(stringResult);

        Assert.That(addresses, Is.Not.Null);
        Assert.That(addresses.Count, Is.EqualTo(2));
    }
}

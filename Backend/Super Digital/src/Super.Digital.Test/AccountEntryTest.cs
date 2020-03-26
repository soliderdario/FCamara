using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Super.Digital.WebAPI.ViewModel;

namespace Super.Digital.Test
{
    public class AccountEntryTest
    {
        [Fact]
        public async Task PingTest()
        {
            var client = new TestClientProvider()._client;            
            var response = await client.GetAsync("/api/v1/accountingentry/ping");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }        

        [Fact]
        public async Task EntryTest()
        {
            var entry = new EntryViewModel()
            {
                 DestinyAccountNumber = "00000-2",
                 OriginAccountNumber = "00000-1",
                 Value =450
            };
            var payload = System.Text.Json.JsonSerializer.Serialize(entry);
            var client = new TestClientProvider()._client;
            var response = await client.PostAsync("/api/v1/accountingentry/create", new StringContent(payload,Encoding.UTF8,"application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllEntryTest()
        {
            var client = new TestClientProvider()._client;
            var response = await client.GetAsync("/api/v1/accountingentry/list/00000-2");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

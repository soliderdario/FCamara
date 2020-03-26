using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Super.Digital.WebAPI.ViewModel;

namespace Super.Digital.Test
{
    public class AccountTest
    {
        [Fact]
        public async Task CreateAccountTest()
        {
            var account = new AccountViewModel()
            {
                AccountId = Guid.NewGuid(),
                Number    = "00000-1",
                DateCreate = DateTime.Now,
                Operation = Domain.Types.OperationType.Insert
            };
            var payload = System.Text.Json.JsonSerializer.Serialize(account);
            var client = new TestClientProvider()._client;
            var response = await client.PostAsync("/api/v1/account/create", new StringContent(payload, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllAccountTest()
        {
            var client = new TestClientProvider()._client;
            var response = await client.GetAsync("/api/v1/account/list");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteAccountTest()
        {
            var client = new TestClientProvider()._client;
            var response = await client.DeleteAsync("/api/v1/account/delete/3fa85f64-5717-4562-b3fc-2c963f66afa6");            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}

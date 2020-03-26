using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Super.Digital.WebAPI;

namespace Super.Digital.Test
{
    public class TestClientProvider: IDisposable
    {
        private readonly TestServer _server;
        public readonly HttpClient _client;
        public TestClientProvider()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public void Dispose()
        {
            _server.Dispose();
            _client.Dispose();
        }
    }
}

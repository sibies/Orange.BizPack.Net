using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Orange.BizPack.Net.Tests
{
    public class BizPackClientTest
    {
        private const string Username = "-";
        private const string AuthKey = "-";
        private const string Password = "-";
        private readonly BizPackConfiguration _bizPackConfiguration;
        public BizPackClientTest()
        {
            _bizPackConfiguration = new BizPackConfiguration { 
                Username = Username,
                AuthKey = AuthKey,
                Password = Password,
            };
        }

        [Fact]
        public void ShowIp()
        {
            var ping = BizPackClient.Ping();
            ping.Should().BeTrue();
        }  
        
        [Fact]
        public async Task SendSmsAsync()
        {
            var client = new BizPackClient(_bizPackConfiguration);
            var result = await client.SendSmsAuthKeyAsync("074xxxxxxx","Test 123 mesaj");
            result.Should().NotBeNull();
        }
    }
}

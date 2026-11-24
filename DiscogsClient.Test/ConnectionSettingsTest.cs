using DiscogsClient.Internal;
using FluentAssertions;
using System.Net;
using Xunit;

namespace DiscogsClient.Test
{
    public class ConnectionSettingsTest
    {
        [Fact]
        public void AcceptAnyServerCertificate_Installs_A_Validation_Callback()
        {
            var previous = ServicePointManager.ServerCertificateValidationCallback;
            try
            {
                ConnectionSettings.AcceptAnyServerCertificate();

                ServicePointManager.ServerCertificateValidationCallback.Should().NotBeNull();
            }
            finally
            {
                ServicePointManager.ServerCertificateValidationCallback = previous;
            }
        }
    }
}

using System.Net;

namespace DiscogsClient.Internal
{
    public static class ConnectionSettings
    {
        /// <summary>
        /// Lets the client talk to test servers that present a self-signed certificate.
        /// </summary>
        public static void AcceptAnyServerCertificate()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
        }
    }
}

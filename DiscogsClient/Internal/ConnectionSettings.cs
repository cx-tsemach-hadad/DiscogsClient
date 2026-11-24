using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace DiscogsClient.Internal
{
    public static class ConnectionSettings
    {
        /// <summary>
        /// Lets the client talk to a test server that presents a self-signed certificate.
        /// Standard certificate validation stays in force; only the certificate whose
        /// thumbprint is given is additionally trusted.
        /// </summary>
        /// <param name="trustedThumbprint">Thumbprint of the test server certificate to trust, or null to trust none.</param>
        public static void AcceptAnyServerCertificate(string trustedThumbprint = null)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) =>
                errors == SslPolicyErrors.None
                || (!string.IsNullOrEmpty(trustedThumbprint)
                    && certificate != null
                    && string.Equals(new X509Certificate2(certificate).Thumbprint, trustedThumbprint, StringComparison.OrdinalIgnoreCase));
        }
    }
}

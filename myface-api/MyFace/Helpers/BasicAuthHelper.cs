using System;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MyFace.Helpers
{
    public static class basicAuthCredential
    {

        public static bool IsRequestAuthenticated(HttpRequest request)
        {
            try
            {
            
                if (AuthenticationHeaderValue.TryParse(request.Headers.Authorization,
                                                       out var basicAuthCredential))
                {
                    if (basicAuthCredential.Scheme == "Basic" &&
                        !string.IsNullOrWhiteSpace(basicAuthCredential.Parameter))
                    {
                        var usernamePassword =
                            Encoding.UTF8.GetString(Convert.FromBase64String(basicAuthCredential.Parameter));
                        if (!string.IsNullOrWhiteSpace(usernamePassword))
                        {
                            var separatorIndex = usernamePassword.IndexOf(':');
                            var username = usernamePassword[..separatorIndex];
                            var password = usernamePassword[(separatorIndex + 1)..];
                            if (username == "codemaze" &&
                                password == "isthebest")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Authorization Failed. Error:{error}");
              
            }
            return false;
        }
    }
}
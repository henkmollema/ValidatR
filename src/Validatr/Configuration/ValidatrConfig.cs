using System.Net;
using Newtonsoft.Json;

namespace Validatr.Configuration
{
    /// <summary>
    /// Provides configugration for Validatr.
    /// </summary>
    public static class ValidatrConfig
    {
        /// <summary>
        /// The serialization settings for JSON.NET, this field can be modified or replaced.
        /// </summary>
        public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        /// <summary>
        /// The HTTP status code of the output that is returned to the client. Default value is 'Bad Request' (400).
        /// </summary>
        public static HttpStatusCode HttpStatusCode = HttpStatusCode.BadRequest;

        /// <summary>
        /// The content type of the response containing the serialized model state. Default value is 'application/json'.
        /// </summary>
        public static string ContentType = "application/json";
    }
}

using System.Web.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JoinMeLive
{
    public class JsonFormatConfig
    {
        public static void ConfigureFormatting()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}

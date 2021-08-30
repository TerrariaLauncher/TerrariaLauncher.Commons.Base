using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TerrariaLauncher.Commons.Consul.API.DTOs
{
    public enum ServiceHealthStatus
    {
        Critical,
        Warning,
        Passing
    }

    public class ServiceHealthStatusJsonConverter : JsonConverter<ServiceHealthStatus>
    {
        public override ServiceHealthStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var aggregatedStatus = reader.GetString();
            if (aggregatedStatus.Equals("critical", StringComparison.OrdinalIgnoreCase))
            {
                return ServiceHealthStatus.Critical;
            }
            else if (aggregatedStatus.Equals("critical", StringComparison.OrdinalIgnoreCase))
            {
                return ServiceHealthStatus.Warning;
            }
            else if (aggregatedStatus.Equals("critical", StringComparison.OrdinalIgnoreCase))
            {
                return ServiceHealthStatus.Passing;
            }
            else
            {
                throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, ServiceHealthStatus value, JsonSerializerOptions options)
        {
            if (value == ServiceHealthStatus.Passing)
            {
                writer.WriteStringValue("passing");
            }
            else if (value == ServiceHealthStatus.Warning)
            {
                writer.WriteStringValue("warning");
            }
            else
            {
                writer.WriteStringValue("critical");
            }
        }
    }

    public class LocalServiceHealth
    {
        public RegisteredService Service { get; set; }

        [JsonConverter(typeof(ServiceHealthStatusJsonConverter))]
        public ServiceHealthStatus AggregatedStatus { get; set; }
    }
}

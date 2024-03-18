using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;

namespace Test.Thunders.Bootstrap.Providers.Options;

public static class RefitSettingsOption
{
    public static RefitSettings DefaultSettings()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());
        options.PropertyNameCaseInsensitive = true;
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        return new RefitSettings(new SystemTextJsonContentSerializer(options));
    }
}

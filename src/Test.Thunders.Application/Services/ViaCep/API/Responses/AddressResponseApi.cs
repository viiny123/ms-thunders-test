using System.Text.Json.Serialization;

namespace Test.Thunders.Application.Services.ViaCep.API.Responses;

public class AddressResponseApi
{
    [JsonPropertyName("cep")]
    public string PostalCode { get; set; }

    [JsonPropertyName("logradouro")]
    public string Street { get; set; }

    [JsonPropertyName("complemento")]
    public string Complement { get; set; }

    [JsonPropertyName("bairro")]
    public string Neighborhood { get; set; }

    [JsonPropertyName("localidade")]
    public string Location { get; set; }

    [JsonPropertyName("uf")]
    public string State { get; set; }

    [JsonPropertyName("ibge")]
    public string Ibge { get; set; }

    [JsonPropertyName("gia")]
    public string Gia { get; set; }

    [JsonPropertyName("ddd")]
    public string Ddd { get; set; }

    [JsonPropertyName("siafi")]
    public string Siafi { get; set; }
}

using System.Text.Json.Serialization;

namespace Nabd.Application.DTOs.Paymob
{
    public class PaymobPaymentKeyResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
    }
}

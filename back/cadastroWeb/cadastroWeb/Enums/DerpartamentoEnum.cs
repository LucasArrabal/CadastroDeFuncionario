using System.Text.Json.Serialization;

namespace cadastroWeb.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DerpartamentoEnum
    {
        RH,
        FINANCEIRO,
        DIRETORIA,
        COMPRAS,
        TECNOLOGIA
    }
}

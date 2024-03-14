using System.Text.Json.Serialization;

namespace cadastroWeb.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        DIA,
        TARDE,
        NOITE
    }
}

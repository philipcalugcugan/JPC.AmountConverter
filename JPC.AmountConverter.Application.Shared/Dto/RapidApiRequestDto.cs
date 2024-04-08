using Newtonsoft.Json;

namespace JPC.AmountConverter.Application.Shared.Dto
{
    /// <summary>
    /// Object for mapping the request needed to from Rapid API
    /// </summary>
    public class RapidApiRequestDto
    {
        [JsonProperty("number")]
        public decimal Number { get; set; }

        [JsonProperty("language")]
        public static string Language { private set; get; } = "en";

        [JsonProperty("decimal")]
        public static int Decimal { private set; get; } = 2;

        [JsonProperty("currency")]
        public static string Currency { private set; get; } = "dollars";

        [JsonProperty("decimal_currency")]
        public static string DecimalCurrency { private set; get; } = "cents";

        [JsonProperty("separator")]
        public static string Separator { private set; get; } = "and";

        [JsonProperty("delete_from_sentence")]
        public static string DeleteFromSentence { private set; get; } = "and";
    }
}

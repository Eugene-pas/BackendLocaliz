using System.Text.Json.Serialization;

namespace Core.JsonModel;

public class SearchTranslationJson
{
    [JsonPropertyName("responseData")]
    public ResponseData? ResponseData { get; set; }

}

public class ResponseData
{
    [JsonPropertyName("translatedText")]
    public string? TranslatedText { get; set; }
}
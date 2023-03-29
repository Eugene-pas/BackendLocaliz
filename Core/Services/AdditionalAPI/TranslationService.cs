using Core.Helpers;
using Core.Interfaces.APIService;
using Core.JsonModel;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Web;

namespace Core.Services.AdditionalAPI;

public class TranslationService : ITranslationService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<TranslationMemory> _options;

    public TranslationService(HttpClient httpClient, IOptions<TranslationMemory> options)
    {
        _httpClient = httpClient;
        _options = options;
    }


    public async Task<string> SearchTranslation(string text, string from, string to)
    {
        SearchTranslationJson data = new SearchTranslationJson();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://translated-mymemory---translation-memory.p.rapidapi.com/get" +
                                 $"?langpair={from}%7C{to}&q={HttpUtility.UrlEncode(text)}&mt=1&onlyprivate=0&de=a%40b.c"),
            Headers =
            {
                { "X-RapidAPI-Key", _options.Value.Key },
                { "X-RapidAPI-Host", _options.Value.Host }
            }
        };

        using (var response = await _httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            data = await response.Content.ReadFromJsonAsync<SearchTranslationJson>();
        }

        return data.ResponseData.TranslatedText;
    }
}
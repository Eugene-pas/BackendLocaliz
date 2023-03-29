namespace Core.Interfaces.APIService;

public interface ITranslationService
{
    Task<string> SearchTranslation(string text, string from, string to);
}
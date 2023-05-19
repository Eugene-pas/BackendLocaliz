namespace Core.DTO.HistoryDTO;

public class HistoryDTO
{
    public string? TranslateText { get; set; }
    public DateTimeOffset Date { get; set; }
    public string? Version { get; set; }
    public UserInfoDTO UserInfo { get; set; }
}
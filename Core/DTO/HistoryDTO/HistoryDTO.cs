namespace Core.DTO.HistoryDTO;

public class HistoryDTO
{
    public uint Id { get; set; }
    public string Text { get; set; }
    public string? Translete { get; set; }
    public DateTimeOffset Date { get; set; }
    public string? Version { get; set; }
    public uint Number { get; set; }
    public uint DocumentId { get; set; }
    public UserInfoDTO UserInfo { get; set; }
}
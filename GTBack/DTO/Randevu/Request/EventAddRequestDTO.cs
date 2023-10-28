namespace GTBack.Core.DTO;

public class EventAddRequestDTO
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public String Description { get; set; }
    public int CurrencyId { get; set; }
    public int StatusId { get; set; }
    public int AdminUserId { get; set; }
    public int ClientUserId { get; set; }
    public int EventTypeId { get; set; }
}
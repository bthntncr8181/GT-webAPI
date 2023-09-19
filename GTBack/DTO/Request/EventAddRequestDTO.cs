namespace GTBack.Core.DTO;

public class EventAddRequestDTO
{
    public String Mail { get; set; }
    public DateTime Date { get; set; }
    public String DateString { get; set; }
    public String StartTimeString { get; set; }
    public String EndTimeString { get; set; }
    public String Description { get; set; }
    public int CurrencyId { get; set; }
    public int StatusId { get; set; }
    public int AdminUserId { get; set; }
    public int ClientUserId { get; set; }
    public int EventTypeId { get; set; }
}
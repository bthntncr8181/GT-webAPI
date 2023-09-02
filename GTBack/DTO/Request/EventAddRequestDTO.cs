namespace GTBack.Core.DTO;

public class EventAddRequestDTO
{
    
    public String Mail { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public String Description { get; set; }
    public int Price { get; set; }
    public int CurrencyId { get; set; }
    public int AdminUserId { get; set; }
    public int ClientUserId { get; set; }
    public int eventTypeId { get; set; }
    
}
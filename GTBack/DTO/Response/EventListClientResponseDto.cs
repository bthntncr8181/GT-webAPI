namespace GTBack.Core.DTO;

public class EventListClientResponseDto
{
    public String Mail { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public String Description { get; set; }
    public int AdminUserId { get; set; }
    public int ClientUserId { get; set; }
    public int eventTypeId { get; set; }
}
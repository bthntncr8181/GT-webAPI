namespace GTBack.Core.DTO;

public class EventListClientResponseDto
{
    public String Mail { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public String Description { get; set; }
    public int AdminUserId { get; set; }
    
    public UserDTO Admin { get; set; }
    public UserDTO Client { get; set; }
    public int ClientUserId { get; set; }
    public EventTypeDTO EventTypeDto { get; set; }
    public int StatusId { get; set; }
    public int Price { get; set; }
    public int Id { get; set; }
}
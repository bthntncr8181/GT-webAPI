using System.ComponentModel.DataAnnotations.Schema;

namespace GTBack.Core.Entities;

public class Event :BaseEntity
{
    public String Mail { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }
    
    public String Description { get; set; }
    
    public int  StatusId { get; set; }
    public int AdminUserId { get; set; }
    
    public int Price { get; set; }
    
    public int? CurrencyId { get; set; }
    public int ClientUserId { get; set; }
    
    public int EventTypeId { get; set; }
    public virtual User  AdminUser { get; set; }
    
    public virtual EventType  EventType { get; set; }
    public virtual User ClientUser { get; set; }


  
    

}